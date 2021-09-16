namespace Accommodation.Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Accommodation.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationDbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Room> Rooms { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
