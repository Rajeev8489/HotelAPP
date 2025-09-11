using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HotelAppUI.Model
{
    public class Room
    {
        internal DateTime CreateDate;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public int TotalRooms { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
