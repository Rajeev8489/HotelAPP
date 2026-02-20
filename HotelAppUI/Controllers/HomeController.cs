using HotelAppUI.Models;
using HotelAppUI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelAppUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookingService _bookingService;

        public HomeController(ILogger<HomeController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _bookingService.GetAllBookingAsync<List<BookingDTO>>();
                var all = response ?? new List<BookingDTO>();
                ViewBag.TotalBookings = all.Count;
                ViewBag.RecentBookings = all.OrderByDescending(b => b.BookingId).Take(5).ToList();
            }
            catch
            {
                ViewBag.TotalBookings = 0;
                ViewBag.RecentBookings = new List<BookingDTO>();
            }
            return View();
        }

        public IActionResult RegistrationForm()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
