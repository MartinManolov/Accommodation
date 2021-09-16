namespace Accommodation.Application.Facilities.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateFacilityCommand(string Name) : IRequest<Facility>
    {
    }

    public class Handler : IRequestHandler<CreateFacilityCommand, Facility>
    {
        private readonly IApplicationDbContext _context;

        public Handler(IApplicationDbContext context)
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
