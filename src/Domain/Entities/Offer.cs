namespace Accommodation.Domain.Entities
{
    using System;

    public class Offer
    {
        public Offer()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string RoomId { get; set; }

        public Room Room { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public decimal PricePerNight { get; set; }

        public int MaxPeople { get; set; }
    }
}