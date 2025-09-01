using HotelApp_Utility;
using HotelAppUI.Model;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HotelAppUI.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel {get;set;}

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
                //HttpResponseMessage apiRespose = await client.SendAsync(message);
                //var apiContent = await apiRespose.Content.ReadAsStringAsync();
                //var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                HttpResponseMessage apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessage = new List<string> { Convert.ToString(ex.Message) },
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
