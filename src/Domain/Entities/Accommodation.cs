namespace Accommodation.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Accommodation.Domain.Common;

    public class Accommodation : AuditableEntity
    {
        public Accommodation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Reviews = new HashSet<Review>();
            this.Rooms = new HashSet<Room>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        public ICollection<string> Facilities { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public int Rating
        {
            get
            {
                return this.Reviews.Sum(x => x.Rating) / this.Reviews.Count;
            }
        }
    }
}
