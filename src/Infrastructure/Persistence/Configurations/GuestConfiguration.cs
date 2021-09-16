namespace Accommodation.Infrastructure.Persistence.Configurations
{
    using Accommodation.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();
        }
    }
}
