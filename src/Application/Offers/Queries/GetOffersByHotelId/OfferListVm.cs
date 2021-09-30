namespace Accommodation.Application.Offers.Queries.GetOffersByHotelId
{
    using System.Collections.Generic;

    public class OfferListVm
    {
        public IList<OfferDto> Offers { get; set; }
    }
}
