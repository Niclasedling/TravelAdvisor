
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.Services
{


    public class UserService : IUserService
    {
        static HttpClient client = new HttpClient();
        public static string searchword;
        string uri = $"https://localhost:44361/User/" + $"{searchword}";
        
        public async Task<UserDto> GetAllUsers()
        {
            searchword = "GetAll";

            UserDto user = new UserDto();
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                user = JsonSerializer.Deserialize<UserDto>(result);
            }
            return user;
        }
        
    }
}
