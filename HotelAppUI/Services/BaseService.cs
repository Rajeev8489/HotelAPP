using HotelApp_Utility;
using HotelAppUI.Model;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;

namespace HotelAppUI.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> SendAsync<T>(APIRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            HttpRequestMessage messsage = new HttpRequestMessage();
            messsage.RequestUri = new Uri(request.Url);
            messsage.Headers.Add("Accept","application/json");
            switch (request.ApiType)
            {
                case SD.ApiType.POST:
                    messsage.Method= HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    messsage.Method = HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    messsage.Method = HttpMethod.Delete;
                    break;
                    default:
                    messsage.Method = HttpMethod.Get;
                    break;
            }
        }
    }
}
