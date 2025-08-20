using AutoMapper;
using HotelAPI.Data;
using HotelAPI.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public BookingController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<BookingDTO>> GetBookings()
        {
            IEnumerable<Booking> bookinglist = _db.Bookings.ToList();
            return Ok(_mapper.Map<List<BookingDTO>>(bookinglist));
        }
        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<BookingDTO>> GetBookingByName(String name)
        {
            var Booking = _db.Bookings.FirstOrDefault(a => a.CustomerName == name);
            return Ok(Booking);
        }
        [HttpPost]
        public ActionResult<BookingDTO> CreateBookings([FromBody] BookingDTO bookingDTO)
        {
            if (_db.Bookings.FirstOrDefault(b => b.CustomerName.ToLower() == bookingDTO.CustomerName.ToLower()) != null)
            {
                return BadRequest(400);
            }
            if (bookingDTO == null)
            {
                return BadRequest("CustomerName is required.");
            }
            if (bookingDTO.BookingId < 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Booking Model = new()
            {
                CustomerName = bookingDTO.CustomerName,
                RoomId = bookingDTO.RoomId,
                Address = bookingDTO.Address,
                City = bookingDTO.City,
                PhoneNumber = bookingDTO.PhoneNumber,
                TotalPrice = bookingDTO.TotalPrice
            };
            _db.Bookings.Add(Model);
            _db.SaveChanges();
            return Ok(Model);
        }
        [HttpPut("{id:int}", Name = "UpdateBooking")]
        public IActionResult UpdateBooking(int id, [FromBody] BookingDTO bookingDTO)
        {
            if (bookingDTO == null || id != bookingDTO.BookingId)
            {
                return BadRequest();
            }
            Booking model = _mapper.Map<Booking>(bookingDTO);
            //Booking model = new()
            //{
            //    BookingId = bookingDTO.BookingId,
            //    RoomId = bookingDTO.RoomId,
            //    CustomerName = bookingDTO.CustomerName,
            //    Address = bookingDTO.Address,
            //    City = bookingDTO.City,
            //    PhoneNumber = bookingDTO.PhoneNumber,
            //    TotalPrice = bookingDTO.TotalPrice
            //};
            _db.Bookings.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "DeleteBooking")]
        public IActionResult DeleteBooking(int id)
        {
            if (id == 0)
            {
                return BadRequest(400);
            }
            var Booking = _db.Bookings.FirstOrDefault(c => c.BookingId == id);
            if (Booking == null)
            {
                return NotFound(404);
            }
            _db.Bookings.Remove(Booking);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialBooking")]
        public IActionResult UpdatePartialBooking(int id, JsonPatchDocument<BookingDTO> PatchBookingDTO)
        {
            if (PatchBookingDTO == null || id == 0)
            {
                return BadRequest(400);
            }
            var booking = _db.Bookings.AsNoTracking().FirstOrDefault(d => d.BookingId == id);
            _db.SaveChanges();
            BookingDTO bookingDTO = new()
            {
                BookingId = booking.BookingId,
                RoomId = booking.RoomId,
                CustomerName = booking.CustomerName,
                Address = booking.Address,
                City = booking.City,
                PhoneNumber = booking.PhoneNumber,
                TotalPrice = booking.TotalPrice
            };
            if (booking == null)
            {
                return BadRequest(400);
            }
            PatchBookingDTO.ApplyTo(bookingDTO);
            Booking Model = new Booking()
            {
                BookingId = bookingDTO.BookingId,
                RoomId = bookingDTO.RoomId,
                CustomerName = bookingDTO.CustomerName,
                Address = bookingDTO.Address,
                City = bookingDTO.City,
                PhoneNumber = bookingDTO.PhoneNumber,
                TotalPrice = bookingDTO.TotalPrice
            };
            _db.Bookings.Update(Model);
            _db.SaveChanges();
            return Ok();
        }
    }
}
