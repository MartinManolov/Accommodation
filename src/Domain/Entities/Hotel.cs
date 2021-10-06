namespace Accommodation.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Accommodation.Domain.Common;

    public class Hotel : AuditableEntity
    {
        public Hotel(string name, string description, string phoneNumber, string email, string country, string city)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Description = description;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Country = country;
            this.City = city;
            this.Reviews = new HashSet<Review>();
            this.Rooms = new HashSet<Room>();
            this.Facilities = new HashSet<Facility>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ICollection<Facility> Facilities { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
