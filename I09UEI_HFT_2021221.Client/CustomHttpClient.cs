using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221.Client
{
    public static class CustomHttpClient
    {
        private const string BaseUri = "http://localhost:5000";
        private static HttpClient _client;
        private const string MediaType = "application/json";

        public static async Task<string> GetRequestAsync(string requestUri)
        {
            using (_client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BaseUri);

                var response = await _client.GetAsync(requestUri);
                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
        }

        public static async Task<string> PostRequestAsync(string requestUri, string json)
        {
            using (_client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BaseUri);
                var content = new StringContent(json, Encoding.UTF8, MediaType);

                var response = await _client.PostAsync(requestUri, content);
                var jsonContent = await response.Content.ReadAsStringAsync();

                return jsonContent;
            }
        }

        public static async Task<string> PutRequestAsync(string requestUri, string json)
        {
            using (_client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BaseUri);
                var content = new StringContent(json, Encoding.UTF8, MediaType);

                var response = await _client.PutAsync(requestUri, content);
                var jsonContent = await response.Content.ReadAsStringAsync();
                
                return jsonContent;
            }
        }
        public static async Task<HttpStatusCode> DeleteRequestAsync(string requestUri)
        {
            using (_client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BaseUri);
                var response = await _client.DeleteAsync(requestUri);

                return response.StatusCode;
            }
        }

    }
}
