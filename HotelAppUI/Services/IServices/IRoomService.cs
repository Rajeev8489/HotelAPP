using HotelAppUI.Models;

namespace HotelAppUI.Services.IServices
{
    public interface IRoomService
    {
        Task<T> GetRoomsAsync<T>();
    }
}
