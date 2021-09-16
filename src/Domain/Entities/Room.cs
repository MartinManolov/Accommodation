namespace Accommodation.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Room
    {
        public Room()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Offers = new HashSet<Offer>();
        }

        public string Id { get; set; }

        public string HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public int Sleeps { get; set; }

        public ICollection<string> Facilities { get; set; }

        public int Size { get; set; }

        public string Description { get; set; }

        public string View { get; set; }

        public ICollection<Offer> Offers { get; private set; }
    }
}