using HotelAppUI.Model;
using HotelAppUI.Models;

namespace HotelAppUI.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
