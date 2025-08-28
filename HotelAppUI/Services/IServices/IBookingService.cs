using HotelAppUI.Models;

namespace HotelAppUI.Services.IServices
{
    public interface IBookingService
    {
        Task<T> GetAllBookingAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(BookingDTO dto);
        Task<T> UpdateAsync<T>(BookingDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
