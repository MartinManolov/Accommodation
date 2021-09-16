namespace Accommodation.Infrastructure.Persistence.Configurations
{
    using Accommodation.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.LocationId)
                .IsRequired();

            builder.Property(e => e.PhoneNumber)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();
        }
    }
}
