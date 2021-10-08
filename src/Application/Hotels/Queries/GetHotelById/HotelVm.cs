namespace Accommodation.Application.Hotels.Queries.GetHotelById
{
    using System.Collections.Generic;
    using Accommodation.Application.Offers.Queries.Common.Models;
    using Accommodation.Application.Reviews.Queries.GetReviewsByHotelId;

    public class HotelVm
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Rating { get; set; }

        public List<string> Facilities { get; set; }

        public ReviewsListVm Reviews { get; set; }

        public OffersListVm Offers { get; set; }
    }
}
