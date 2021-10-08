namespace Accommodation.Application.Hotels.Queries.GetHotelById
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Exceptions;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Offers.Queries.GetActiveOffersByHotelId;
    using Accommodation.Application.Reviews.Queries.GetReviewsByHotelId;
    using MediatR;

    public record GetHotelByIdQuery(string HotelId) : IRequest<HotelVm>
    {
    }

    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public GetHotelByIdQueryHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<HotelVm> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = _context.Hotels
                .Where(x => x.Id == request.HotelId)
                .Select(x => new HotelVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Country = x.Country,
                    Latitude = x.Location.Latitude,
                    Longitude = x.Location.Longitude,
                    City = x.City,
                    Description = x.Description,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Facilities = x.Facilities.Select(x => x.Name).ToList(),
                    Rating = x.Reviews.Count == 0 ? 0 : x.Reviews.Sum(x => x.Rating) / x.Reviews.Count,
                }).FirstOrDefault();

            if (hotel == null)
            {
                throw new NotFoundException($"Hotel with id \"{request.HotelId}\" is not found !");
            }

            hotel.Reviews = await _mediator.Send(new GetReviewsByHotelIdQuery(request.HotelId));
            hotel.Offers = await _mediator.Send(new GetActiveOffersByHotelIdQuery(request.HotelId));

            return hotel;
        }
    }
}
