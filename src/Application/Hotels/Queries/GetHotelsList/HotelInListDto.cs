namespace Accommodation.Application.Hotels.Queries.GetHotelsList
{
    using Accommodation.Application.Common.Mappings;
    using Accommodation.Domain.Entities;

    public class HotelInListDto : IMapFrom<Hotel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int Rating { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
