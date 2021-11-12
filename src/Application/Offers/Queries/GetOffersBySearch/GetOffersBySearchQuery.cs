namespace Accommodation.Application.Offers.Queries.GetOffersBySearch
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Offers.Queries.Common.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public record  GetOffersBySearchQuery (
          string Parameter,
          DateTime? CheckIn,
          DateTime? CheckOut,
          int? People) : IRequest<OffersListVm>
    {
    }

    public class GetOffersBySearchQueryHandler : IRequestHandler<GetOffersBySearchQuery, OffersListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _date;

        public GetOffersBySearchQueryHandler(IApplicationDbContext context, IDateTime date)
        {
            _context = context;
            _date = date;
        }

        public async Task<OffersListVm> Handle(GetOffersBySearchQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Offers.AsQueryable().Where(x => x.CheckInDate >= _date.Now
                                                    && x.MaxReservations > x.Reservations.Count);

            if(!string.IsNullOrEmpty(request.Parameter))
            {
                result = result.Where(x => x.Hotel.Name == request.Parameter ||
                                           x.Hotel.City == request.Parameter ||
                                           x.Hotel.Country == request.Parameter);
            }

            if(request.CheckIn.HasValue)
            {
                result = result.Where(x => x.CheckInDate >= request.CheckIn);
            }

            if(request.CheckOut.HasValue)
            {
                result = result.Where(x => x.CheckOutDate <= request.CheckOut);
            }

            if(request.People.HasValue)
            {
                result = result.Where(x => x.MaxPeople >= request.People);
            }

            var offers = await result.Select(x => new OfferDto
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
                .OrderByDescending(x => x.PricePerNight)
                .ToListAsync(cancellationToken);

            var vm = new OffersListVm() { Offers = offers };

            return vm;
        }
    }
}
