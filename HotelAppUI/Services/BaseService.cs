using HotelApp_Utility;
using HotelAppUI.Model;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;
using System.Text.Json.Serialization;

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
            try
            {
                var client = _httpClientFactory.CreateClient();
                HttpRequestMessage message = new HttpRequestMessage();
                message.RequestUri = new Uri(request.Url);
                message.Headers.Add("Accept", "application/json");
                switch (request.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage apiRespose = null;
                var apiContent = await apiRespose.Content.ReadAsStreamAsync();
                var APIRespose = JsonConverter.DeserializeObject<T>(apiContent);
                return (APIRespose == null) ? null : APIRespose;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessage = new List<string> { Convert.ToString(ex.Message) },
                };
                var res = JsonConverter.SerializeObject(dto);
                var APIResponse = JsonConverter.DeserializeObject<T>(res);
                return (APIResponse == null) ? null : APIResponse;
            }
        }
    }
}
