namespace Accommodation.Domain.Entities
{
    using System;
    using Accommodation.Domain.Common;

    public class Facility : AuditableEntity
    {
        public Facility(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
