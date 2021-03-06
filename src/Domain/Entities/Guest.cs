namespace Accommodation.Domain.Entities
{
    using System;
    using Accommodation.Domain.Common;

    public class Guest : AuditableEntity
    {
        public Guest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}