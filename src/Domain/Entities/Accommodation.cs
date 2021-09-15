namespace Accommodation.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Accommodation.Domain.Common;

    public class Accommodation : AuditableEntity
    {
        public Accommodation(string name, string desccription,
                            string[] facilities, string phoneNumber)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Description = desccription;
            this.Facilities = facilities;
            this.PhoneNumber = phoneNumber;
            this.Reviews = new HashSet<Review>();
            this.Rooms = new HashSet<Room>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        public string Description { get; set; }

        public ICollection<string> Facilities { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Review> Reviews { get; private set; }

        public ICollection<Room> Rooms { get; private set; }

        public int Rating
        {
            get
            {
                return this.Reviews.Sum(x => x.Rating) / this.Reviews.Count;
            }
        }
    }
}
