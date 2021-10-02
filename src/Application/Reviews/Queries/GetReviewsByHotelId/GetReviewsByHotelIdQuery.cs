namespace Accommodation.Application.Reviews.Queries.GetReviewsByHotelId
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Interfaces;
    using MediatR;

    public record GetReviewsByHotelIdQuery(string HotelId) : IRequest<ReviewsListVm>
    {
    }

    public class GetReviewsByHotelIdQueryHandler : IRequestHandler<GetReviewsByHotelIdQuery, ReviewsListVm>
    {
        private readonly IApplicationDbContext _context;

        public GetReviewsByHotelIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewsListVm> Handle(GetReviewsByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = new ReviewsListVm
            {
                Reviews = _context.Reviews
                .Where(x => x.HotelId == request.HotelId)
                .Select(x => new ReviewDto
                {
                    GuestName = x.Guest.FirstName + " " + x.Guest.LastName,
                    Content = x.Content,
                    Rating = x.Rating,
                    Date = x.Created,
                })
                .OrderByDescending(x => x.Date)
                .ToList(),
            };

            return reviews;
        }
    }
}
