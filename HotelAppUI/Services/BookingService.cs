using HotelApp_Utility;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;

namespace HotelAppUI.Services
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string bookingUrl;
        public BookingService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<BaseService> logger)
            : base(httpClientFactory, logger)
        {
            _httpClientFactory = httpClientFactory;
            bookingUrl = configuration.GetValue<string>("ServiceUrl:HotelApi");
        }
        public Task<T> GetAllBookingAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = bookingUrl + "/api/BookingAPI"
            });
        }
        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = bookingUrl + $"/api/BookingAPI/{id}"
            });
        }
        public Task<T> CreateAsync<T>(BookingDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = bookingUrl + "/api/BookingAPI"
            });
        }
        public Task<T> UpdateAsync<T>(BookingDTO dTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dTO,
                Url = bookingUrl + $"/api/BookingAPI/{dTO.BookingId}"
            });
        }
        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = bookingUrl + $"/api/BookingAPI/{id}"
            });
        }
    }
}
