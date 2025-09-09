using System.ComponentModel.DataAnnotations;

namespace HotelAppUI.Models
{
    public class BookingDTO
    {
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Room ID is required")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Range(1000000000, 9999999999999, ErrorMessage = "Enter valid phone number")]
        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "Total price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than 0")]
        public double TotalPrice { get; set; }
    }
}
