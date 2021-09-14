namespace Accommodation.Domain.Entities
{
    using System;
    using global::Accommodation.Domain.ValueObjects;

    public class Review
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string GuestId { get; set; }

        public Guest Guest { get; set; }

        public string AccommodationId { get; set; }

        public Accommodation Accommodation { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }
    }
}
