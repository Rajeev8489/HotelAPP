using HotelAppUI.Model;

namespace HotelAppUI.Services.IServices
{
    public interface IAuthService
    {
        Task<T> RegisterAsync<T>(RegistrationForm form);
        Task<T> LoginAsync<T>(LoginRequest request);
    }
}



