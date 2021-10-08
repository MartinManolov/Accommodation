using Accommodation.Application.Common.Interfaces;
using Accommodation.Application.Offers.Queries.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accommodation.Application.Offers.Queries.GetOfferById
{
    public record GetOfferByIdQuery(string OfferId) : IRequest<OfferDto>
    {
    }

    public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, OfferDto>
    {
        private readonly IApplicationDbContext _context;

        public GetOfferByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OfferDto> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var vm = _context.Offers.Where(x => x.Id == request.OfferId)
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
                 .FirstOrDefault();

            return vm;
        }
    }
}
