namespace Accommodation.Infrastructure.Persistence.Configurations
{
    using Accommodation.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(e => e.GuestId)
                .IsRequired();

            builder.Property(e => e.HotelId)
                .IsRequired();

            builder.Property(e => e.Content)
                .HasMaxLength(350);
        }
    }
}
