namespace Accommodation.Application.Facilities.Commands.CreateFacility
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateFacilityCommand(string Name) : IRequest<Facility>
    {
    }

    public class CreateFacilityCommandHandler : IRequestHandler<CreateFacilityCommand, Facility>
    {
        private readonly IApplicationDbContext _context;

        public CreateFacilityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Facility> Handle(CreateFacilityCommand request, CancellationToken cancellationToken)
        {
            var facility = new Facility(request.Name);

            await _context.Facilities.AddAsync(facility);
            await _context.SaveChangesAsync(cancellationToken);

            return facility;
        }
    }
}
