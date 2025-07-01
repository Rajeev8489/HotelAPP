using HotelAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelAPI.Model;

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
        public ActionResult<IEnumerable<RoomDTO>> GetRooms()
        {
            return Ok(_db.Rooms.ToList());
        }
    }
}
