namespace Accommodation.Application.Offers.Queries.GetOffersByHotelId
{
    using System;
    using Accommodation.Application.Common.Mappings;
    using Accommodation.Domain.Entities;
    using AutoMapper;

    public class OfferDto : IMapFrom<Offer>
    {
        public string Id { get; set; }

        public string RoomId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public decimal PricePerNight { get; set; }

        public int MaxPeople { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OfferDto>();
        }
    }
}
