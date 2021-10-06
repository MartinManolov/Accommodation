namespace Accommodation.Application.Hotels.Queries.GetHotelsByCity
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Hotels.Queries.GetHotelsList;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public record GetHotelsByCityQuery(string City) : IRequest<HotelsListVm>
    {
    }

    public class GetHotelsByCityQueryHandler : IRequestHandler<GetHotelsByCityQuery, HotelsListVm>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelsByCityQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HotelsListVm> Handle(GetHotelsByCityQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _context.Hotels
                .Where(x => x.City == request.City)
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
