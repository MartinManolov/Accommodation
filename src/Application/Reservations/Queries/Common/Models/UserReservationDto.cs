namespace Accommodation.Application.Reservations.Queries.Common.Models.GetUserReservations
{
    using System;

    public class UserReservationDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string HotelName { get; set; }

        public string HotelPhoneNumber { get; set; }

        public string HotelEmail { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public decimal Price { get; set; }

        public int Nights { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
    }
}
