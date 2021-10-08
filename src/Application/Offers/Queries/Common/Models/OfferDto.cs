namespace Accommodation.Application.Offers.Queries.Common.Models
{
    using System;

    public class OfferDto
    {
        public string Id { get; set; }

        public string RoomId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int Nights { get; set; }

        public decimal PricePerNight { get; set; }

        public decimal WholePrice { get; set; }

        public int MaxPeople { get; set; }

        public int RemainingReservation { get; set; }
    }
}
