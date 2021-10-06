namespace Accommodation.Application.Hotels.Commands.DeleteHotel
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Exceptions;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public record DeleteHotelCommand(string Id) : IRequest
    {
    }

    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteHotelCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (hotel == null)
            {
                    throw new NotFoundException(nameof(Hotel), request.Id);
            }

            if (hotel.CreatedBy != _currentUserService.UserId)
            {
                    throw new ForbiddenAccessException();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
