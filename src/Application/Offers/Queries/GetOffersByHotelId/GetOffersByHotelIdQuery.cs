namespace Accommodation.Application.Offers.Queries.GetOffersByHotelId
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public record GetOffersByHotelIdQuery(string HotelId) : IRequest<OfferListVm>
    {
    }

    public class GetOffersByHotelIdHandler : IRequestHandler<GetOffersByHotelIdQuery, OfferListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOffersByHotelIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OfferListVm> Handle(GetOffersByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var offers = await _context.Offers.Where(x => x.HotelId == request.HotelId)
                 .ProjectTo<OfferDto>(_mapper.ConfigurationProvider)
                 .OrderByDescending(x => x.PricePerNight)
                 .ToListAsync(cancellationToken);

            var vm = new OfferListVm
            {
                Offers = offers,
            };

            return vm;
        }
    }
}
