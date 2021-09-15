namespace Accommodation.Domain.Entities
{
    using System;
    using global::Accommodation.Domain.Common;

    public class Location : AuditableEntity
    {
        public Location(decimal latitude, decimal longitude)
        {
            this.Id = Guid.NewGuid().ToString();
            this.ChangeLocation(latitude, longitude);
        }

        public string Id { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public void ChangeLocation(decimal latitude, decimal longitude)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new Exception($"Latitude {latitude} should be between -90,90 !");
            }

            if (longitude < -180 || longitude > 180)
            {
                throw new Exception($"Longitude {longitude} should be between -180,180 !");
            }

            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}
