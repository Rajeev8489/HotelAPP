using AutoMapper;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelAppUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingController> _logger;

        private readonly IRoomService _roomService;

        public BookingController(IBookingService bookingService, IRoomService roomService, IMapper mapper, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _roomService = roomService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> IndexBooking()
        {
            try
            {
                var response = await _bookingService.GetAllBookingAsync<List<BookingDTO>>();
                var bookings = response ?? new List<BookingDTO>();
                return View(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving bookings");
                TempData["ErrorMessage"] = "An error occurred while retrieving bookings.";
                return View(new List<BookingDTO>());
            }
        }

        public async Task<IActionResult> Create()
        {
            await LoadRoomsAsync();
            return View(new BookingDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingDTO bookingDTO)
        {
            if (!ModelState.IsValid)
            {
                await LoadRoomsAsync();
                return View(bookingDTO);
            }

            try
            {
                var response = await _bookingService.CreateAsync<BookingDTO>(bookingDTO);
                if (response != null && response.BookingId > 0)
                {
                    TempData["SuccessMessage"] = "Booking created successfully.";
                    return RedirectToAction(nameof(Confirmation), new { id = response.BookingId });
                }
                if (response != null)
                {
                    TempData["SuccessMessage"] = "Booking created successfully.";
                    return RedirectToAction(nameof(IndexBooking));
                }

                TempData["ErrorMessage"] = "Failed to create booking.";
                await LoadRoomsAsync();
                return View(bookingDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating booking");
                TempData["ErrorMessage"] = "An error occurred while creating the booking.";
                await LoadRoomsAsync();
                return View(bookingDTO);
            }
        }

        public async Task<IActionResult> EditBooking(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid booking ID.";
                return RedirectToAction(nameof(IndexBooking));
            }

            try
            {
                var booking = await _bookingService.GetAsync<BookingDTO>(id);
                if (booking == null)
                {
                    TempData["ErrorMessage"] = "Booking not found.";
                    return RedirectToAction(nameof(IndexBooking));
                }

                await LoadRoomsAsync();
                return View(booking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving booking for edit, ID: {BookingId}", id);
                TempData["ErrorMessage"] = "An error occurred while retrieving the booking.";
                return RedirectToAction(nameof(IndexBooking));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBooking(BookingDTO bookingDTO)
        {
            if (!ModelState.IsValid)
            {
                await LoadRoomsAsync();
                return View(bookingDTO);
            }

            try
            {
                var response = await _bookingService.UpdateAsync<object>(bookingDTO);
                if (response != null)
                {
                    TempData["SuccessMessage"] = "Booking updated successfully.";
                    return RedirectToAction(nameof(IndexBooking));
                }

                TempData["ErrorMessage"] = "Failed to update booking.";
                await LoadRoomsAsync();
                return View(bookingDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating booking, ID: {BookingId}", bookingDTO.BookingId);
                TempData["ErrorMessage"] = "An error occurred while updating the booking.";
                await LoadRoomsAsync();
                return View(bookingDTO);
            }
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid booking ID.";
                return RedirectToAction(nameof(IndexBooking));
            }

            try
            {
                var booking = await _bookingService.GetAsync<BookingDTO>(id);
                if (booking == null)
                {
                    TempData["ErrorMessage"] = "Booking not found.";
                    return RedirectToAction(nameof(IndexBooking));
                }

                return View(booking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving booking for delete, ID: {BookingId}", id);
                TempData["ErrorMessage"] = "An error occurred while retrieving the booking.";
                return RedirectToAction(nameof(IndexBooking));
            }
        }

        [HttpPost, ActionName("DeleteBooking")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBookingConfirmed(int id)
        {
            try
            {
                await _bookingService.DeleteAsync<object>(id);
                TempData["SuccessMessage"] = "Booking deleted successfully.";
                return RedirectToAction(nameof(IndexBooking));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting booking, ID: {BookingId}", id);
                TempData["ErrorMessage"] = "An error occurred while deleting the booking.";
                return RedirectToAction(nameof(IndexBooking));
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExportCsv()
        {
            try
            {
                var response = await _bookingService.GetAllBookingAsync<List<BookingDTO>>();
                var bookings = response ?? new List<BookingDTO>();

                var csv = new System.Text.StringBuilder();
                csv.AppendLine("BookingId,RoomId,CustomerName,Address,City,PhoneNumber,TotalPrice");

                foreach (var b in bookings)
                {
                    csv.AppendLine($"{b.BookingId},{b.RoomId},\"{b.CustomerName}\",\"{b.Address}\",\"{b.City}\",{b.PhoneNumber},{b.TotalPrice:F2}");
                }

                var bytes = System.Text.Encoding.UTF8.GetBytes(csv.ToString());
                return File(bytes, "text/csv", $"bookings-{DateTime.Now:yyyyMMdd-HHmm}.csv");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error exporting bookings");
                TempData["ErrorMessage"] = "An error occurred while exporting bookings.";
                return RedirectToAction(nameof(IndexBooking));
            }
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            if (id <= 0)
                return RedirectToAction(nameof(IndexBooking));

            try
            {
                var booking = await _bookingService.GetAsync<BookingDTO>(id);
                if (booking == null)
                    return RedirectToAction(nameof(IndexBooking));
                return View(booking);
            }
            catch
            {
                return RedirectToAction(nameof(IndexBooking));
            }
        }

        private async Task LoadRoomsAsync()
        {
            try
            {
                var rooms = await _roomService.GetRoomsAsync<List<RoomDTO>>();
                ViewBag.Rooms = rooms ?? new List<RoomDTO>();
            }
            catch
            {
                ViewBag.Rooms = new List<RoomDTO>();
            }
        }
    }
}
