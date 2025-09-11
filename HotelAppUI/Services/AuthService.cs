using HotelApp_Utility;
using HotelAppUI.Model;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;

namespace HotelAppUI.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;

        public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<BaseService> logger)
            : base(httpClientFactory, logger)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration.GetValue<string>("ServiceUrl:HotelApi");
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

        public Task<T> LoginAsync<T>(LoginRequest request)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Data = request,
                Url = _apiBaseUrl + "/api/Auth/login"
            });
        }
    }
}


