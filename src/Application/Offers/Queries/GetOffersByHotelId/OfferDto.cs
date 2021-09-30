namespace Accommodation.Application.Offers.Queries.GetOffersByHotelId
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Accommodation.Application.Common.Mappings;
    using Accommodation.Domain.Entities;

    public class OfferDto : IMapFrom<Offer>
    {
        public string Id { get; set; }

        public string RoomId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public decimal PricePerNight { get; set; }

        public int MaxPeople { get; set; }
    }
}
