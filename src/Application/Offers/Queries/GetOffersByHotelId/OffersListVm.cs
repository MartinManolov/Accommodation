namespace Accommodation.Application.Offers.Queries.GetOffersByHotelId
{
    using System.Collections.Generic;

    public class OffersListVm
    {
        public IList<OfferDto> Offers { get; set; }
    }
}
