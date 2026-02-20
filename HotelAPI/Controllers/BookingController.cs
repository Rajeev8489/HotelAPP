using AutoMapper;
using HotelAPI.Data;
using HotelAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    [Route("api/BookingAPI")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingController> _logger;

        public BookingController(AppDbContext db, IMapper mapper, ILogger<BookingController> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetBookings()
        {
            try
            {
                var bookings = await _db.Bookings.ToListAsync();
                return Ok(_mapper.Map<List<BookingDTO>>(bookings));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving bookings");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving bookings.");
            }
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookingDTO>> GetBooking(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid booking ID.");
            }

            try
            {
                var booking = await _db.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
                if (booking == null)
                {
                    return NotFound($"Booking with ID {id} not found.");
                }

                return Ok(_mapper.Map<BookingDTO>(booking));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving booking with ID {BookingId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the booking.");
            }
        }

        [HttpGet("name/{name}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookingDTO>> GetBookingByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Customer name is required.");
            }

            try
            {
                var booking = await _db.Bookings
                    .FirstOrDefaultAsync(b => b.CustomerName.ToLower() == name.ToLower());

                if (booking == null)
                {
                    return NotFound($"No booking found for customer: {name}");
                }

                return Ok(_mapper.Map<BookingDTO>(booking));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving booking by name: {CustomerName}", name);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the booking.");
            }
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookingDTO>> CreateBookings([FromBody] BookingDTO bookingDTO)
        {
            if (bookingDTO == null)
            {
                return BadRequest("Booking data is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingBooking = await _db.Bookings
                    .FirstOrDefaultAsync(b => b.CustomerName.ToLower() == bookingDTO.CustomerName.ToLower());

                if (existingBooking != null)
                {
                    return Conflict($"A booking already exists for customer: {bookingDTO.CustomerName}");
                }

                var booking = _mapper.Map<Booking>(bookingDTO);
                await _db.Bookings.AddAsync(booking);
                await _db.SaveChangesAsync();

                var createdBookingDto = _mapper.Map<BookingDTO>(booking);
                return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, createdBookingDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating booking");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the booking.");
            }
        }

        [HttpPut("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDTO bookingDTO)
        {
            if (bookingDTO == null)
            {
                return BadRequest("Booking data is required.");
            }

            if (id != bookingDTO.BookingId)
            {
                return BadRequest("Booking ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingBooking = await _db.Bookings.FindAsync(id);
                if (existingBooking == null)
                {
                    return NotFound($"Booking with ID {id} not found.");
                }

                _mapper.Map(bookingDTO, existingBooking);
                _db.Bookings.Update(existingBooking);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating booking with ID {BookingId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the booking.");
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid booking ID.");
            }

            try
            {
                var booking = await _db.Bookings.FindAsync(id);
                if (booking == null)
                {
                    return NotFound($"Booking with ID {id} not found.");
                }

                _db.Bookings.Remove(booking);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting booking with ID {BookingId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the booking.");
            }
        }

        [HttpPatch("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePartialBooking(int id, JsonPatchDocument<BookingDTO> patchBookingDTO)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid booking ID.");
            }

            if (patchBookingDTO == null)
            {
                return BadRequest("Patch document is required.");
            }

            try
            {
                var booking = await _db.Bookings.FindAsync(id);
                if (booking == null)
                {
                    return NotFound($"Booking with ID {id} not found.");
                }

                var bookingDto = _mapper.Map<BookingDTO>(booking);
                patchBookingDTO.ApplyTo(bookingDto, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _mapper.Map(bookingDto, booking);
                _db.Bookings.Update(booking);
                await _db.SaveChangesAsync();

                return Ok(_mapper.Map<BookingDTO>(booking));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating partial booking with ID {BookingId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the booking.");
            }
        }
    }
}
