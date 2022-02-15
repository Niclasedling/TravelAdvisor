using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.ApiClient
{
    public class ApiClient<T> where T : class
    {
        private readonly HttpClient httpClient;
        private readonly string controller;

        public ApiClient(HttpClient httpClient, string controller)
        {
            this.httpClient = httpClient;
            this.controller = controller;
            this.httpClient.BaseAddress = new Uri($"http://localhost:41418/{controller}/");
        }

        public async Task<T> GetAsync(Guid id)
        {
            string path = $"GetById?id={id}";
            var response = await httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }
        public async Task<List<T>> GetListAsync(Guid id)
        {
            string path = $"GetById?id={id}";
            var response = await httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<T>>(responseString);
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            string path = $"Delete?id={id}";
            var response = await httpClient.DeleteAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }

            return true;
        }

        public async Task<Guid> PostAsync<T>(T Data)
        {
            string path = "Create";
            var response = await httpClient.PostAsync(path, JsonContent.Create(Data));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Guid>(responseString);
        }

        public async Task<bool> PutAsync<T>(T Data)
        {
            string path = "Update";
            var response = await httpClient.PostAsync(path, JsonContent.Create(Data));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{this.httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }

            return true;
        }

        public async Task<List<T>> GetListAsync(string path)
        {
            var response = await httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{this.httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }

            var responseString = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<List<T>>(responseString);
        }
        public async Task<T> GetListAsync(string path, string data)
        {
            var response = await httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{this.httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }

            var responseString = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async Task<List<T>> GetListAsyncByCity(string city)
        {
            string path = $"GetListByCity?city={city}";
            var response = await httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<T>>(responseString);
        }

        public async Task<List<T>> GetListAsyncById(Guid id)
        {
            string path = $"GetListById?id={id}";
            var response = await httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Api '{httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
            }
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<T>>(responseString);
        }

    }

}
