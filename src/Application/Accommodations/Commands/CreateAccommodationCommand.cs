namespace Accommodation.Application.Accommodations.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Locations.Commands;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateAccommodationCommand (
        string Name,
        string Desccription,
        string[] Facilities,
        string PhoneNumber,
        decimal LocationLatitude,
        decimal LocationLongitude) : IRequest<string>
    {
    }

    public class Handler : IRequestHandler<CreateAccommodationCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public Handler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateAccommodationCommand request, CancellationToken cancellationToken)
        {
            var accommodation = new Accommodation(request.Name, request.Desccription,
                                                 request.Facilities, request.PhoneNumber);

            var location = new CreateLocationCommand(request.LocationLatitude, request.LocationLongitude);
            var locationId = await _mediator.Send(location);

            accommodation.LocationId = locationId;

            await _context.Accommodations.AddAsync(accommodation);
            await _context.SaveChangesAsync(cancellationToken);

            return accommodation.Id;
        }
    }
}
