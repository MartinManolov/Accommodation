namespace Accommodation.Infrastructure.Persistence.Configurations
{
    using Accommodation.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(e => e.HotelId)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(200);
        }
    }
}
