namespace HotelAppUI.Models
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public required string CustomerName { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public int PhoneNumber { get; set; }
        public double TotalPrice { get; set; }
    }
}
