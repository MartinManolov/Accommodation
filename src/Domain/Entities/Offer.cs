namespace Accommodation.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using Accommodation.Domain.Common;

    public class Offer : AuditableEntity
    {
        public Offer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Reservations = new HashSet<Reservation>();
        }

        public string Id { get; set; }

        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public string RoomId { get; set; }

        public Room Room { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public decimal PricePerNight { get; set; }

        public int MaxPeople { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}