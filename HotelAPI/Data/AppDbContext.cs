using Microsoft.EntityFrameworkCore;
using HotelAPI.Model;

namespace HotelAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)

    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public Guid Id { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData
                (
                 new Room()
                 {
                     RoomId = 1,
                     Name = "Single Room",
                     Type = "Deluxe",
                     TotalRooms = 1,
                     CreateDate = DateTime.Now,
                 },
                 new Room()
                 {
                     RoomId = 2,
                     Name = "Double",
                     Type = "Luxury",
                     TotalRooms = 2,
                     CreateDate = DateTime.Now
                 },
                  new Room()
                  {
                      RoomId = 3,
                      Name = "Triple",
                      Type = "Super Luxury",
                      TotalRooms = 3,
                      CreateDate = DateTime.Now
                  }
                );

            modelBuilder.Entity<Booking>().HasData(
                new Booking()
                {
                    BookingId = 1,
                    RoomId = 1,
                    CustomerName = "Rajeev",
                    Address = "UtharaHalli",
                    City = "Bangalore",
                    PhoneNumber = 123456789
                }

                );
        }



    }
    }
