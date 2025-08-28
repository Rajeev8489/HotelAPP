using HotelAppUI.Models;
using HotelAppUI.Services.IServices;

namespace HotelAppUI.Services
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string bookingUrl;
        public BookingService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            this.bookingUrl = bookingUrl;
        }
        public Task<T> GetAllBookingAsync<T>()
        {
            throw new NotImplementedException();
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
