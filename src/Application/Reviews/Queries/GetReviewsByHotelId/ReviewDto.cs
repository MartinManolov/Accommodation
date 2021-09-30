namespace Accommodation.Application.Reviews.Queries.GetReviewsByHotelId
{
    using System;

    public class ReviewDto
    {
        public string GuestName { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        public DateTime Date { get; set; }
    }
}
