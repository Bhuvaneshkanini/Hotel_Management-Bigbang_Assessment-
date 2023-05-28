using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_Bigbang_Assessment1_.Models
{
    public class HotelDbContext:DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        { }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Amenities> Amenities { get; set; }


        public DbSet<Booking> Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>()
                .HasOne(b => b.Hotel)
                .WithMany(a => a.Rooms)
                .HasForeignKey(p => p.HotelId);


            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Hotel)
                .WithMany(a => a.Bookings)
                .HasForeignKey(p => p.HotelId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(a => a.Bookings)
                .HasForeignKey(p => p.RoomNo)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
