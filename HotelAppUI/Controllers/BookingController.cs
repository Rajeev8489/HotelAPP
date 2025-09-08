using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HotelAppUI.Model;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;
using Newtonsoft.Json;

namespace HotelAppUI.Controllers
{

    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        public async Task <IActionResult> IndexBooking()
        {
            List<BookingDTO> list = new();
            var response = await _bookingService.GetAllBookingAsync<List<BookingDTO>>();
            if (response != null)
            {
                list = response;
            }
            //var response = _bookingService.GetAllBookingAsync<APIResponse>();
            //if (response != null)
            //{
            //    list = JsonConvert.DeserializeObject<List<BookingDTO>>(Convert.ToString(response.Result));
            //}
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingDTO bookingDTO)
        {
            if (ModelState.IsValid)
            {
                var bookingDto = _mapper.Map<BookingDTO>(bookingDTO);
                var response = await _bookingService.CreateAsync<BookingDTO>(bookingDto);
                if (response != null)
                {
                    return RedirectToAction(nameof(IndexBooking));
                }
            }
            return View(bookingDTO);
        }
    }
}
