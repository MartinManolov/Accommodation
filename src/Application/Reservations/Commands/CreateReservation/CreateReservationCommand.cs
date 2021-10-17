namespace Accommodation.Application.Reservations.Commands.CreateReservation
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Guests.Commands.CreateGuest;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateReservationCommand (
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string OfferId) : IRequest<string>
    {
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CreateReservationCommandHandler(IApplicationDbContext context,
                                              IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var guestId = await _mediator.Send(new CreateGuestCommand(request.FirstName,
                                                                request.LastName,
                                                                request.Email,
                                                                request.PhoneNumber));
            var hotelId = _context.Offers
                            .Where(x => x.Id == request.OfferId)
                            .Select(x => x.HotelId)
                            .FirstOrDefault();

            var reservation = new Reservation
            {
                GuestId = guestId,
                HotelId = hotelId,
                OfferId = request.OfferId,
            };

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync(cancellationToken);

            return reservation.Id;
        }
    }
}
