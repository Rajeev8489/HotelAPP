namespace HotelAppUI.Models
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public int TotalRooms { get; set; }
    }
}
