namespace Accommodation.Application.Hotels.Queries.GetHotelsList
{
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
            var hotels = await _context.Hotels
                .ProjectTo<HotelInListDto>(_mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Rating)
                .ToListAsync(cancellationToken);

            var vm = new HotelsListVm
            {
                Hotels = hotels,
            };

            return vm;
        }
    }
}
