
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
using TravelAdvisor.ViewModels;
using TravelAdvisor.Views;
using Xamarin.Forms;

namespace TravelAdvisor.Services
{


    public class UserService:IUserService
    {
        private readonly ApiClient<UserDto> _userClient;
        private readonly INavService _navService;
        private readonly AuthClient<UserLoginDto> _authClient;

        public UserService(HttpClient httpClient)
        {
            _userClient = new ApiClient<UserDto>(httpClient, "User");
            _navService = DependencyService.Get<INavService>();
            _authClient = new AuthClient<UserLoginDto>(httpClient, "User");
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            return await _userClient.GetAsync(id);
      
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userClient.DeleteAsync(id);
        }

        public async Task<Guid> CreateUser(UserCreateDto user)
        {
            await App.Current.MainPage.DisplayAlert("Successful", "User created", "OK");
            await _navService.NavigateTo<LoginPageViewModel>();
            return await _userClient.PostAsync(user);


        }

        public async Task<bool> UpdateUser(UserUpdateDto user)
        {
            return await _userClient.PutAsync(user);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {

           var item = await _userClient.GetListAsync("GetAll");
            return item;
        }
        public async Task<bool> Login(UserLoginDto user)
        {
            return await _authClient.Login(user);
        }
        
    }


}


