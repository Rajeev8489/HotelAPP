using HotelAPI.Data;
using HotelAPI.Model;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AppDbContext db, IJwtService jwtService, ILogger<AuthController> logger)
        {
            _db = db;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegistrationForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { isSuccess = false, message = "Invalid data", errors = ModelState });
            }

            try
            {
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for user: {UserName}", form?.UserName);
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { isSuccess = false, message = "An error occurred during registration." });
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { isSuccess = false, message = "Username and password are required." });
            }

            try
            {
                var user = await _db.Users
                    .FirstOrDefaultAsync(u => u.UserName == request.UserName && u.Password == request.Password);

                if (user == null)
                {
                    return Unauthorized(new { isSuccess = false, message = "Invalid username or password" });
                }

                var token = _jwtService.GenerateToken(user);
                return Ok(new 
                { 
                    isSuccess = true, 
                    message = "Login successful", 
                    token, 
                    userId = user.UserId, 
                    userName = user.UserName 
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user: {UserName}", request.UserName);
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { isSuccess = false, message = "An error occurred during login." });
            }
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
