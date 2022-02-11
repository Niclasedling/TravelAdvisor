
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
            try
            {
                return await _userClient.GetAsync(id);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }

        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                return await _userClient.DeleteAsync(id);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public async Task<Guid> CreateUser(UserCreateDto user)
        {
            

            try
            {
                await App.Current.MainPage.DisplayAlert("Successful", "User created", "OK");
                await _navService.NavigateTo<LoginPageViewModel>();
                return await _userClient.PostAsync(user);
            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }


        }

        public async Task<bool> UpdateUser(UserUpdateDto user)
        {
            try
            {
                return await _userClient.PutAsync(user);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public async Task<List<UserDto>> GetAllUsers()
        {

           
            try
            {
                var item = await _userClient.GetListAsync("GetAll");
                return item;
            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }
        public async Task<Guid> Login(UserLoginDto user)
        {
            try
            {
                return await _authClient.Login(user);
            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message); 
            }
            
        }
        
    }


}


