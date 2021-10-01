namespace Accommodation.Application.Hotels.Queries.GetHotelsList
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetHotelsListQuery : IRequest<HotelsListVm>
    {
    }

    public class GetHotelsListQueryHandler : IRequestHandler<GetHotelsListQuery, HotelsListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetHotelsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HotelsListVm> Handle(GetHotelsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var hotels = await _context.Hotels
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
            catch (System.Exception)
            {

                throw new System.Exception();
            }

        }
    }
}
