namespace Accommodation.Application.Offers.Queries.GetActiveOffersByHotelId
{
    using System.Collections.Generic;

    public class OffersListVm
    {
        public IList<OfferDto> Offers { get; set; }
    }
}
