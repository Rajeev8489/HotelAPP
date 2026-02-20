using HotelAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<UserDetails> Users { get; set; }
        public DbSet<RegistrationForm> RegistrationForms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Room data
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    RoomId = 1,
                    Name = "Single",
                    Type = "Deluxe",
                    TotalRooms = 1
                },
                new Room
                {
                    RoomId = 2,
                    Name = "Double",
                    Type = "Luxury",
                    TotalRooms = 2
                },
                new Room
                {
                    RoomId = 3,
                    Name = "Triple",
                    Type = "Super Luxury",
                    TotalRooms = 3
                }
            );

            // Seed Booking data
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    BookingId = 1,
                    RoomId = 1,
                    CustomerName = "Rajeev",
                    Address = "UttaraHalli",
                    City = "Bangalore",
                    PhoneNumber = 123456789
                },
                new Booking
                {
                    BookingId = 2,
                    RoomId = 2,
                    CustomerName = "Suresh",
                    Address = "Jublee Hills",
                    City = "Hyderabad",
                    PhoneNumber = 545856265
                }
            );
        }
    }
}
