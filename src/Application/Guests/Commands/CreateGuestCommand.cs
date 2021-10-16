namespace Accommodation.Application.Guests.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateGuestCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber) : IRequest<string>
    {
    }

    public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateGuestCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = new Guest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync(cancellationToken);

            return guest.Id;
        }
    }
}
