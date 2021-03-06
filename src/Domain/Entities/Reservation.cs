namespace Accommodation.Domain.Entities
{
    using System;
    using Accommodation.Domain.Common;

    public class Reservation : AuditableEntity
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string GuestId { get; set; }

        public Guest Guest { get; set; }

        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public string OfferId { get; set; }

        public Offer Offer { get; set; }
    }
}
