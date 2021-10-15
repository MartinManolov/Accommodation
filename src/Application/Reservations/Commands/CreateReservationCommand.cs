namespace Accommodation.Application.Reservations.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateReservationCommand (string HotelId, string OfferId) : IRequest<string>
    {
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;

        public CreateReservationCommandHandler(IApplicationDbContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<string> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation
            {
                GuestId = _userService.UserId,
                HotelId = request.HotelId,
                OfferId = request.OfferId,
            };

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync(cancellationToken);

            return reservation.Id;
        }
    }
}
