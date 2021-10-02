namespace Accommodation.Application.Reviews.Commands.CreateReview
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using Accommodation.Domain.Entities;
    using MediatR;

    public record CreateReviewCommand (string GuestId, string HotelId, string Content, int Rating) : IRequest<string>
    {
    }

    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateReviewCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                GuestId = request.GuestId,
                HotelId = request.HotelId,
                Content = request.Content,
                Rating = request.Rating,
            };

            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync(cancellationToken);

            return review.Id;
        }
    }
}
