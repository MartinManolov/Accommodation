namespace Accommodation.Application.Rooms.Queries.GetRoomById
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Offers.Queries.Common.Models;
    using Accommodation.Application.Rooms.Queries.Common.Models;
    using MediatR;

    public record GetRoomByIdQuery(string RoomId) : IRequest<RoomDto>
    {
    }

    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto>
    {
        private readonly IApplicationDbContext _context;

        public GetRoomByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RoomDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var vm = _context.Rooms
                .Where(x => x.Id == request.RoomId)
                .Select(x => new RoomDto
                {
                    Id = x.Id,
                    Size = x.Size,
                    Sleeps = x.Sleeps,
                    Description = x.Description,
                    View = x.View,
                    Facilities = x.Facilities.Select(f => f.Name).ToList(),
                    Offers = x.Offers.Select(o => new OfferDto
                    {
                        Id = x.Id,
                        RoomId = o.RoomId,
                        CheckInDate = o.CheckInDate,
                        CheckOutDate = o.CheckOutDate,
                        Nights = (o.CheckOutDate - o.CheckInDate).Days,
                        RemainingReservation = o.MaxReservations - o.Reservations.Count,
                        MaxPeople = o.MaxPeople,
                        PricePerNight = o.PricePerNight,
                        WholePrice = (o.CheckOutDate - o.CheckInDate).Days * o.PricePerNight,
                    }).ToList(),
                }).FirstOrDefault();

            return vm;
        }
    }
}
