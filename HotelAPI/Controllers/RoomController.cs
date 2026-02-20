using AutoMapper;
using HotelAPI.Data;
using HotelAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomController> _logger;

        public RoomController(AppDbContext db, IMapper mapper, ILogger<RoomController> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            try
            {
                var rooms = await _db.Rooms.ToListAsync();
                return Ok(_mapper.Map<List<RoomDTO>>(rooms));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rooms");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving rooms.");
            }
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoomDTO>> GetRoomById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid room ID.");
            }

            try
            {
                var room = await _db.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);
                if (room == null)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                return Ok(_mapper.Map<RoomDTO>(room));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving room with ID {RoomId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the room.");
            }
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoomDTO>> CreateRooms([FromBody] RoomDTO roomDTO)
        {
            if (roomDTO == null)
            {
                return BadRequest("Room data is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingRoom = await _db.Rooms
                    .FirstOrDefaultAsync(r => r.RoomId == roomDTO.RoomId);

                if (existingRoom != null)
                {
                    return Conflict($"Room with ID {roomDTO.RoomId} already exists.");
                }

                var room = _mapper.Map<Room>(roomDTO);
                await _db.Rooms.AddAsync(room);
                await _db.SaveChangesAsync();

                var createdRoomDto = _mapper.Map<RoomDTO>(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomId }, createdRoomDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating room");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the room.");
            }
        }

        [HttpPut("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomDTO roomDTO)
        {
            if (roomDTO == null)
            {
                return BadRequest("Room data is required.");
            }

            if (id != roomDTO.RoomId)
            {
                return BadRequest("Room ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingRoom = await _db.Rooms.FindAsync(id);
                if (existingRoom == null)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                _mapper.Map(roomDTO, existingRoom);
                _db.Rooms.Update(existingRoom);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating room with ID {RoomId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the room.");
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid room ID.");
            }

            try
            {
                var room = await _db.Rooms.FindAsync(id);
                if (room == null)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                _db.Rooms.Remove(room);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting room with ID {RoomId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the room.");
            }
        }

        [HttpPatch("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePartialRoom(int id, JsonPatchDocument<RoomDTO> patchRoomDTO)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid room ID.");
            }

            if (patchRoomDTO == null)
            {
                return BadRequest("Patch document is required.");
            }

            try
            {
                var room = await _db.Rooms.FindAsync(id);
                if (room == null)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                var roomDto = _mapper.Map<RoomDTO>(room);
                patchRoomDTO.ApplyTo(roomDto, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _mapper.Map(roomDto, room);
                _db.Rooms.Update(room);
                await _db.SaveChangesAsync();

                return Ok(_mapper.Map<RoomDTO>(room));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating partial room with ID {RoomId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the room.");
            }
        }
    }
}
