using HotelApp_Utility;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;

namespace HotelAppUI.Services
{
    public class BookingService : BaseService, IBookingService
    {
        private const string BookingApiPath = "/api/BookingAPI";
        private readonly string _apiBaseUrl;

        public BookingService(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ILogger<BaseService> logger,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, logger, httpContextAccessor)
        {
            _apiBaseUrl = configuration.GetValue<string>("ServiceUrl:HotelApi");
        }

        public Task<T> GetAllBookingAsync<T>()
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = BuildBookingUrl()
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = BuildBookingUrl(id)
            });
        }

        public Task<T> CreateAsync<T>(BookingDTO dto)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = BuildBookingUrl()
            });
        }

        public Task<T> UpdateAsync<T>(BookingDTO dto)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = BuildBookingUrl(dto.BookingId)
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = BuildBookingUrl(id)
            });
        }

        private string BuildBookingUrl(int? id = null)
        {
            var url = $"{_apiBaseUrl}{BookingApiPath}";
            return id.HasValue ? $"{url}/{id.Value}" : url;
        }
    }
}
