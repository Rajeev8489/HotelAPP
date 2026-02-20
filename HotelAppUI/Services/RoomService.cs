using HotelApp_Utility;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;

namespace HotelAppUI.Services
{
    public class RoomService : BaseService, IRoomService
    {
        private const string RoomApiPath = "/api/Room";
        private readonly string _apiBaseUrl;

        public RoomService(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ILogger<BaseService> logger,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, logger, httpContextAccessor)
        {
            _apiBaseUrl = configuration.GetValue<string>("ServiceUrl:HotelApi");
        }

        public Task<T> GetRoomsAsync<T>()
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = $"{_apiBaseUrl}{RoomApiPath}"
            });
        }
    }
}
