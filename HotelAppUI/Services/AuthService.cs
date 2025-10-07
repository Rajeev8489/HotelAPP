using HotelApp_Utility;
using HotelAppUI.Model;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace HotelAppUI.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<BaseService> logger, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, logger, httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration.GetValue<string>("ServiceUrl:HotelApi");
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<T> RegisterAsync<T>(RegistrationForm form)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Data = form,
                Url = _apiBaseUrl + "/api/Auth/register"
            });
        }

        public async Task<T> LoginAsync<T>(LoginRequest request)
        {
            var result = await SendAsync<dynamic>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Data = request,
                Url = _apiBaseUrl + "/api/Auth/login"
            });

            try
            {
                if (result != null && result.isSuccess == true && result.token != null)
                {
                    _httpContextAccessor.HttpContext?.Session?.SetString("jwtToken", (string)result.token);
                }
            }
            catch { }

            return (T)result;
        }
    }
}


