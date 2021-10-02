namespace Accommodation.Application.Rooms.Commands.CreateRoom
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Facilities.Commands.CreateFacility;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateRoomCommand(
        string HotelId,
        int Sleeps,
        int Size,
        string Description,
        string View,
        List<string> Facilities) : IRequest<string>
    {
    }

    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CreateRoomCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room
            {
                HotelId = request.HotelId,
                Sleeps = request.Sleeps,
                Size = request.Size,
                Description = request.Description,
                View = request.View,
            };

            foreach (var facilityFromInput in request.Facilities)
            {
                var facility = await _mediator.Send(new CreateFacilityCommand(facilityFromInput));
                room.Facilities.Add(facility);
            }

            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync(cancellationToken);

            return room.Id;
        }
    }
}
