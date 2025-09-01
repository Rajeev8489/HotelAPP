using HotelApp_Utility;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;

namespace HotelAppUI.Services
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string bookingUrl;
        public BookingService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
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
            throw new NotImplementedException();
        }
        public Task<T> CreateAsync<T>(BookingDTO dto)
        {
            throw new NotImplementedException();
        }
        public Task<T> UpdateAsync<T>(BookingDTO dTO)
        {
            throw new NotImplementedException();
        }
        public Task<T> DeleteAsync<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
