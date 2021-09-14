using Accommodation.Domain.Common;
using Accommodation.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accommodation.Domain.Entities
{
    public class Location : AuditableEntity
    {
        public Location()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public Latitude Latitude { get; set; }

        public Longitude Longitude { get; set; }

        public Accommodation Accommodation { get; set; }
    }
}
