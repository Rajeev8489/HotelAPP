using HotelAPI.Data;
using HotelAPI.Model;
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

        public RoomController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<RoomDTO>> GetRooms()
        {
            return Ok(_db.Rooms.ToList());
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<RoomDTO>> GetRoomById(int id)
        {
            var Room = _db.Rooms.FirstOrDefault(u => u.RoomId == id);
            return Ok(Room);
        }
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> CreateRooms([FromBody] RoomDTO roomDTO)
        {
            if (roomDTO == null)
            {
                return BadRequest("Room data is required.");
            }

            var existingRoom = await _db.Rooms.FirstOrDefaultAsync(v => v.RoomId == roomDTO.RoomId);
            if (existingRoom != null)
            {
                return BadRequest("Room with the same ID already exists.");
            }

            if (roomDTO.RoomId < 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid Room ID.");
            }

            Room model = new()
            {
                Name = roomDTO.Name,
                Type = roomDTO.Type,
                TotalRooms = roomDTO.TotalRooms
            };

            await _db.Rooms.AddAsync(model);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRooms), new { id = model.RoomId }, roomDTO);
        }
        [HttpPut("{id:int}", Name = "UpdateRoom")]
        public IActionResult UpdateRoom(int id, [FromBody] RoomDTO roomDTO)
        {
            if (roomDTO == null || id != roomDTO.RoomId)
            {
                return BadRequest();
            }
            Room model = new()
            {
                RoomId = roomDTO.RoomId,
                Name = roomDTO.Name,
                Type = roomDTO.Type,
                TotalRooms = roomDTO.TotalRooms
            };

            _db.Rooms.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeleteRoom")]
        public IActionResult DeleteRoom(int id)
        {
            if (id == 0)
            {
                return BadRequest(400);
            }
            var Room = _db.Rooms.FirstOrDefault(c => c.RoomId == id);
            if (Room == null)
            {
                return NotFound(404);
            }
            _db.Rooms.Remove(Room);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialRoom")]
        public IActionResult UpdatePartialRoom(int id, JsonPatchDocument<RoomDTO> PatchRoomDTO)
        {
            if (PatchRoomDTO == null || id == 0)
            {
                return BadRequest(400);
            }
            var room = _db.Rooms.AsNoTracking().FirstOrDefault(d => d.RoomId == id);
            _db.SaveChanges();
            RoomDTO roomDTO = new()
            {
                RoomId = room.RoomId,
                Name = room.Name,
                Type = room.Type,
                TotalRooms = room.TotalRooms
            };
            if (room == null)
            {
                return BadRequest(400);
            }
            PatchRoomDTO.ApplyTo(roomDTO);
            Room Model = new Room()
            {
                RoomId = roomDTO.RoomId,
                Name = roomDTO.Name,
                Type = roomDTO.Type,
                TotalRooms = roomDTO.TotalRooms
            };
            _db.Rooms.Update(Model);
            _db.SaveChanges();
            return Ok();
        }

    }
}
