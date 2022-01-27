using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Interfaces;
using TravelAdvisor.ViewModels;
using TravelAdvisor.Views;
using Xamarin.Forms;

namespace TravelAdvisor.Services
{
    public class LoginService : ILoginService
    {

        private readonly IUserService _userService;
        private readonly INavService _navService;
        public LoginService()
        {
            _userService = DependencyService.Get<IUserService>();
            _navService = DependencyService.Get<INavService>();
        }
        public async Task Login(string Email, string Password)
        {
            var users = await _userService.GetAllUsers();

            var answer = users.Find(x => x.Email == Email && x.Password == null); // Null tillfälligt

            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                if (answer != null)
                {
                    await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                    //Navigate to Main page after successfully login  
                    await _navService.NavigateTo<MainPageViewModel>();
                    
                   
                }
                else await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
               
            }
            
        }
        

    }
}
