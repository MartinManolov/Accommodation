namespace Accommodation.Domain.Entities
{
    using System;

    public class Reservation
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string GuestId { get; set; }

        public Guest Guest { get; set; }

        public string AccommpdationId { get; set; }

        public Accommodation Accommodation { get; set; }

        public decimal Prce { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
