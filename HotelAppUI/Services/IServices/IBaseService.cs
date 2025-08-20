using HotelAppUI.Models;
using HotelAppUI.Model;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
namespace HotelAppUI.Services.IServices
{
    public interface IBaseService
    {
        //APIResponse responseModel { get; set}
        Task<T> SendAsync <T>(APIRequest apiRequest);
    }
}
