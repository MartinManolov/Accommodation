namespace Accommodation.Application.Locations.Commands.CreateLocation
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateLocationCommand (decimal Latitude, decimal Longitude) : IRequest<string>
    {
    }

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateLocationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = new Location(request.Latitude, request.Longitude);

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync(cancellationToken);

            return location.Id;
        }
    }
}
