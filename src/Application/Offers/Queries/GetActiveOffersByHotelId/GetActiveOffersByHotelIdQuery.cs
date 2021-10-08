namespace Accommodation.Application.Offers.Queries.GetActiveOffersByHotelId
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Offers.Queries.Common.Models;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public record GetActiveOffersByHotelIdQuery(string HotelId) : IRequest<OffersListVm>
    {
    }

    public class GetActiveOffersByHotelIdQueyHandler : IRequestHandler<GetActiveOffersByHotelIdQuery, OffersListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDateTime _date;

        public GetActiveOffersByHotelIdQueyHandler(IApplicationDbContext context, IDateTime date)
        {
            _context = context;
            _date = date;
        }

        public async Task<OffersListVm> Handle(GetActiveOffersByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var offers = await _context.Offers.Where(x => x.HotelId == request.HotelId
                                                    && x.CheckInDate >= _date.Now
                                                    && x.MaxReservations > x.Reservations.Count)
                 .Select(x => new OfferDto
                 {
                     Id = x.Id,
                     RoomId = x.RoomId,
                     CheckInDate = x.CheckInDate,
                     CheckOutDate = x.CheckOutDate,
                     Nights = (x.CheckOutDate - x.CheckInDate).Days,
                     RemainingReservation = x.MaxReservations - x.Reservations.Count,
                     MaxPeople = x.MaxPeople,
                     PricePerNight = x.PricePerNight,
                     WholePrice = (x.CheckOutDate - x.CheckInDate).Days * x.PricePerNight,
                 })
                 .OrderBy(x => x.PricePerNight)
                 .ToListAsync(cancellationToken);

            var vm = new OffersListVm
            {
                Offers = offers,
            };

            return vm;
        }
    }
}
