using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Interfaces;

namespace TravelAdvisor.Services
{
    public class LoginService : ILoginService
    {
        public async Task Login(string Email, string Password)
        {
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                if (Email == "abc@gmail.com" && Password == "1234")
                {
                    await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                    //Navigate to Main page after successfully login  
                    //await NavigationService.NavigateTo<MainPageViewModel>();
                }
                else await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");

            }
        }

        public Task Register(string Email, string Password, string Firstname, string Lastname)
        {
            throw new NotImplementedException();
        }
    }
}
