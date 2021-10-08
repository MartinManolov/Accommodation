namespace Accommodation.Application.Rooms.Queries.Common.Models
{
    using System.Collections.Generic;
    using Accommodation.Application.Offers.Queries.Common.Models;
    using Accommodation.Domain.Entities;

    public class RoomDto
    {
        public string Id { get; set; }

        public int Sleeps { get; set; }

        public int Size { get; set; }

        public string Description { get; set; }

        public string View { get; set; }

        public List<string> Facilities { get; set; }

        public List<OfferDto> Offers { get; set; }
    }
}
