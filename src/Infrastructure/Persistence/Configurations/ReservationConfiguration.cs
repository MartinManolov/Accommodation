namespace Accommodation.Infrastructure.Persistence.Configurations
{
    using Accommodation.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(e => e.GuestId)
                .IsRequired();

            builder.Property(e => e.HotelId)
                .IsRequired();
        }
    }
}
