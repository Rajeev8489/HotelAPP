using System;
using System.ComponentModel.DataAnnotations;

namespace HotelAppUI.Model
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public required string CustomerName { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public int PhoneNumber { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        

    }
}
