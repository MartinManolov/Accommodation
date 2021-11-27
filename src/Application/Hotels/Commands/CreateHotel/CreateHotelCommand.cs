namespace Accommodation.Application.Accommodations.Commands.CreateHotel
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Application.Facilities.Commands.CreateFacility;
    using Accommodation.Application.Locations.Commands.CreateLocation;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateHotelCommand (
        string Name,
        string Description,
        List<CreateFacilityCommand> Facilities,
        string PhoneNumber,
        string Email,
        string Cuntry,
        string City,
        decimal LocationLatitude,
        decimal LocationLongitude) : IRequest<string>
    {
    }

    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CreateHotelCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = new Hotel(request.Name, request.Description, request.PhoneNumber, request.Email, request.Cuntry, request.City);

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
