namespace Accommodation.Application.Hotels.Queries.GetHotelsByCity
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Hotels.Queries.GetHotelsList;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public record GetHotelsByCountryQuery(string Country) : IRequest<HotelsListVm>
    {
    }

    public class GetHotelsByCountryQueryHandler : IRequestHandler<GetHotelsByCountryQuery, HotelsListVm>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelsByCountryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HotelsListVm> Handle(GetHotelsByCountryQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _context.Hotels
                .Where(x => x.Country == request.Country)
                .Select(x => new HotelInListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    City = x.City,
                    Country = x.Country,
                    PhoneNumber = x.PhoneNumber,
                    Rating = x.Reviews.Count == 0 ? 0 : x.Reviews.Sum(x => x.Rating) / x.Reviews.Count,
                })
                .ToListAsync(cancellationToken);

            var vm = new HotelsListVm
            {
                Hotels = hotels,
            };

            return vm;
        }
    }
}