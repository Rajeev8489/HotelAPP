using HotelAPI.Data;
using HotelAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AuthController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { isSuccess = false, message = "Invalid data" });
            }

            var exists = await _db.Users.AnyAsync(u => u.UserName == form.UserName);
            if (exists)
            {
                return Conflict(new { isSuccess = false, message = "Username already exists" });
            }

            var user = new UserDetails
            {
                UserName = form.UserName,
                Password = form.Password
            };

            await _db.Users.AddAsync(user);
            await _db.RegistrationForms.AddAsync(form);
            await _db.SaveChangesAsync();

            return Ok(new { isSuccess = true, message = "Registration successful" });
        }

        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { isSuccess = false, message = "Invalid credentials" });
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName && u.Password == request.Password);
            if (user == null)
            {
                return Unauthorized(new { isSuccess = false, message = "Invalid username or password" });
            }

            return Ok(new { isSuccess = true, message = "Login successful", userId = user.UserId, userName = user.UserName });
        }
    }
}



