namespace Accommodation.Domain.Entities
{
    using System;
    using Accommodation.Domain.Common;

    public class Review : AuditableEntity
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string GuestId { get; set; }

        public Guest Guest { get; set; }

        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }
    }
}
