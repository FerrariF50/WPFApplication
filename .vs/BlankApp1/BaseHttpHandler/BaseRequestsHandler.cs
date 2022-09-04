using BlankApp1.Dto;
using BlankApp1.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlankApp1.BaseHttpHandler
{
    public class BaseRequestsHandler : IBaseRequestsHandler
    {
        private static HttpClient _httpClient;

        public BaseRequestsHandler()
        {
            if (_httpClient == null)
                _httpClient = new HttpClient();
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task AddAsync(string url, CustomerRequestDto dto)
        {
            try
            {
                var obj = JsonConvert.SerializeObject(dto);
                StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);
                var result = JsonConvert.DeserializeObject<IntResponse>(await response.Content.ReadAsStringAsync());

                if (result.HasError)
                {
                    MessageBox.Show(result.Error);
                    return; 
                }
                MessageBox.Show("User is added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task DeleteAsync(string url)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(url);

                if ((int)response.StatusCode == 200)
                {
                    MessageBox.Show("Succesful user is deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task UpdateAsync(string url, CustomerRequestDto dto)
        {
            try
            {
                var obj = JsonConvert.SerializeObject(dto);
                StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(url, content);
                var result = JsonConvert.DeserializeObject<IntResponse>(await response.Content.ReadAsStringAsync());

                if (result.HasError)
                {
                    MessageBox.Show(result.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("User is updated");
        }
    }
}
