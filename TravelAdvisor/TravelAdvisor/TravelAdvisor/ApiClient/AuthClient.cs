using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.ApiClient
{
    public class AuthClient<T> where T : class
    {
        private readonly HttpClient httpClient;
        private readonly string controller;

        public AuthClient(HttpClient httpClient, string controller)
        {
            this.httpClient = httpClient;
            this.controller = controller;
            this.httpClient.BaseAddress = new Uri($"http://localhost:41418/{controller}/");
        }

        public async Task<bool> Login(UserLoginDto user)
        {
            
         
                string path = "Login";
                var response = await httpClient.PostAsync(path, JsonContent.Create(user));

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Api '{httpClient.BaseAddress}{path}' responded with {response.StatusCode}");
                }

                var responseString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(responseString);
            
        }
    }
}
