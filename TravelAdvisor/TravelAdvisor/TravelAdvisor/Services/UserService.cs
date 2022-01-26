
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TravelAdvisor.ApiClient;
using TravelAdvisor.Models;

namespace TravelAdvisor.Services
{


    public class UserService:IUserService
    {
        private readonly ApiClient<UserDto> userClient;

        public UserService(HttpClient httpClient)
        {
            userClient = new ApiClient<UserDto>(httpClient, "User");
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            return await userClient.GetAsync(id);
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await userClient.DeleteAsync(id);
        }

        public async Task<Guid> CreateUser(UserCreateDto user)
        {
            return await userClient.PostAsync(user);
        }

        public async Task<bool> UpdateUser(UserUpdateDto user)
        {
            return await userClient.PutAsync( user);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {

           var item = await userClient.GetListAsync("GetAll");
            return item;
        }
    }


}


