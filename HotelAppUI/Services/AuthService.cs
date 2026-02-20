using HotelApp_Utility;
using HotelAppUI.Model;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;

namespace HotelAppUI.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private const string AuthApiPath = "/api/Auth";
        private readonly string _apiBaseUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ILogger<BaseService> logger,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, logger, httpContextAccessor)
        {
            _apiBaseUrl = configuration.GetValue<string>("ServiceUrl:HotelApi");
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<T> RegisterAsync<T>(RegistrationForm form)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Data = form,
                Url = BuildAuthUrl("register")
            });
        }

        public async Task<T> LoginAsync<T>(LoginRequest request)
        {
            var result = await SendAsync<dynamic>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Data = request,
                Url = BuildAuthUrl("login")
            });

            try
            {
                if (result != null && result.isSuccess == true && result.token != null)
                {
                    _httpContextAccessor.HttpContext?.Session?.SetString("jwtToken", (string)result.token);
                }
            }
            catch
            {
                // Token storage failed, but we still return the result
            }

            return (T)result;
        }

        private string BuildAuthUrl(string endpoint)
        {
            return $"{_apiBaseUrl}{AuthApiPath}/{endpoint}";
        }
    }
}


