using HotelAppUI.Model;
using HotelAppUI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelAppUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginRequest());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                var response = await _authService.LoginAsync<dynamic>(request);
                if (response != null && response.isSuccess == true)
                {
                    TempData["SuccessMessage"] = "Login successful";
                    return RedirectToAction("Index", "Home");
                }
                TempData["ErrorMessage"] = response?.message ?? "Login failed";
                return View(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed");
                TempData["ErrorMessage"] = "An error occurred during login.";
                return View(request);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegistrationForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            try
            {
                var response = await _authService.RegisterAsync<dynamic>(form);
                if (response != null && response.isSuccess == true)
                {
                    TempData["SuccessMessage"] = "Registration successful. Please login.";
                    return RedirectToAction("Login");
                }
                TempData["ErrorMessage"] = response?.message ?? "Registration failed";
                return View(form);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration failed");
                TempData["ErrorMessage"] = "An error occurred during registration.";
                return View(form);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            TempData["SuccessMessage"] = "Logged out";
            return RedirectToAction("Index", "Home");
        }
    }
}


