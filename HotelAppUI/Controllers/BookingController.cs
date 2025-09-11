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

        public BookingController(IBookingService bookingService, IMapper mapper, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingDTO bookingDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(bookingDTO);
            }

            try
            {
                var response = await _bookingService.CreateAsync<BookingDTO>(bookingDTO);
                if (response != null)
                {
                    TempData["SuccessMessage"] = "Booking created successfully.";
                    return RedirectToAction(nameof(IndexBooking));
                }

                TempData["ErrorMessage"] = "Failed to create booking.";
                return View(bookingDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating booking");
                TempData["ErrorMessage"] = "An error occurred while creating the booking.";
                return View(bookingDTO);
            }
        }

        public async Task<IActionResult> EditBooking(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            try
            {
                var booking = await _bookingService.GetAsync<BookingDTO>(id);
                if (booking == null)
                {
                    return NotFound();
                }
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
                return View(bookingDTO);
            }

            try
            {
                var response = await _bookingService.UpdateAsync<object>(bookingDTO);
                TempData["SuccessMessage"] = "Booking updated successfully.";
                return RedirectToAction(nameof(IndexBooking));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating booking, ID: {BookingId}", bookingDTO.BookingId);
                TempData["ErrorMessage"] = "An error occurred while updating the booking.";
                return View(bookingDTO);
            }
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            try
            {
                var booking = await _bookingService.GetAsync<BookingDTO>(id);
                if (booking == null)
                {
                    return NotFound();
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
    }
}
