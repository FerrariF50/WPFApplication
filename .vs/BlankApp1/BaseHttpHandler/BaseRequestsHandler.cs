using BlankApp1.Dto;
using BlankApp1.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.BaseHttpHandler
{
    public class BaseRequestsHandler : IBaseRequestsHandler
    {
        private readonly HttpClient _httpClient;

        public BaseRequestsHandler(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task AddAsync(string url, CustomerRequestDto dto)
        {
            var obj = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var result = JsonConvert.DeserializeObject<IntResponse>(await response.Content.ReadAsStringAsync());

            if (result.HasError)
            {
                throw new Exception("Customer not added");
            }
        }
        public async Task DeleteAsync(string url)
        {
            await _httpClient.DeleteAsync(url);
        }
        public async Task UpdateAsync(string url, CustomerRequestDto dto)
        {
            var obj = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            var result = JsonConvert.DeserializeObject<IntResponse>(await response.Content.ReadAsStringAsync());

            if (result.HasError)
            {
                throw new Exception("User is not update");
            }
        }
    }
}
