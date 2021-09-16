namespace Accommodation.Application.Accommodations.Commands
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Facilities.Commands;
    using Accommodation.Application.Locations.Commands;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateHotelCommand (
        string Name,
        string Desccription,
        List<CreateFacilityCommand> Facilities,
        string PhoneNumber,
        string Email,
        decimal LocationLatitude,
        decimal LocationLongitude) : IRequest<string>
    {
    }

    public class Handler : IRequestHandler<CreateHotelCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public Handler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = new Hotel(request.Name, request.Desccription, request.PhoneNumber, request.Email);

            var facilities = new List<Facility>();
            foreach (var facility in request.Facilities)
            {
                facilities.Add(await _mediator.Send(facility));
            }

            hotel.Facilities = facilities;

            var location = new CreateLocationCommand(request.LocationLatitude, request.LocationLongitude);
            var locationId = await _mediator.Send(location);

            hotel.LocationId = locationId;

            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync(cancellationToken);

            return hotel.Id;
        }
    }
}
