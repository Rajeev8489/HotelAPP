using HotelApp_Utility;
using HotelAppUI.Model;
using HotelAppUI.Models;
using HotelAppUI.Services.IServices;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace HotelAppUI.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BaseService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(IHttpClientFactory httpClientFactory, ILogger<BaseService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<T> SendAsync<T>(APIRequest request)
        {
            try
            {
                using var client = _httpClientFactory.CreateClient();
                using var message = CreateHttpRequestMessage(request);

                var response = await client.SendAsync(message);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("API request failed with status {StatusCode}: {Content}",
                        response.StatusCode, content);
                    return HandleErrorResponse<T>(response.StatusCode, content);
                }

                return DeserializeResponse<T>(content);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for URL: {Url}", request.Url);
                return HandleException<T>(ex);
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "Request timeout for URL: {Url}", request.Url);
                return HandleException<T>(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error for URL: {Url}", request.Url);
                return HandleException<T>(ex);
            }
        }

        private HttpRequestMessage CreateHttpRequestMessage(APIRequest request)
        {
            var message = new HttpRequestMessage
            {
                RequestUri = new Uri(request.Url)
            };

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

            if (request.Data != null && (request.ApiType == SD.ApiType.POST || request.ApiType == SD.ApiType.PUT))
            {
                var jsonPayload = JsonConvert.SerializeObject(request.Data);
                message.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            }

            var token = request.Token ?? _httpContextAccessor.HttpContext?.Session?.GetString("jwtToken");
            if (!string.IsNullOrWhiteSpace(token))
            {
                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return message;
        }

        private T DeserializeResponse<T>(string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize response: {Content}", content);
                return HandleException<T>(ex);
            }
        }

        private T HandleErrorResponse<T>(System.Net.HttpStatusCode statusCode, string content)
        {
            var errorResponse = new APIResponse
            {
                IsSuccess = false,
                Message = $"API request failed with status: {statusCode}",
                ErrorMessage = new List<string> { content }
            };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(errorResponse));
        }

        private T HandleException<T>(Exception ex)
        {
            var errorResponse = new APIResponse
            {
                IsSuccess = false,
                Message = "An error occurred while processing the request",
                ErrorMessage = new List<string> { ex.Message }
            };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
