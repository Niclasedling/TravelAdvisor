using System;
using System.Collections.Generic;
using System.Text;
using TravelAdvisor.Services;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public SignUpPageViewModel(INavService naviService) : base(naviService)
        {
            //Code for creating the ViewModel


        }

        public override void Init()
        {
            //Code for initialize the ViewModel
        }
        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }
        private async void Register()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please check your entrys", "OK");
            else
            {
                if (!string.IsNullOrEmpty(Email) || !string.IsNullOrEmpty(Password) || !string.IsNullOrEmpty(Firstname) || !string.IsNullOrEmpty(Lastname))
                {
                    await App.Current.MainPage.DisplayAlert("Registration Succsecful", "", "Ok");
                    //Navigate to Main page after successfully login  
                    await NavigationService.NavigateTo<MainPageViewModel>();
                }
                else await App.Current.MainPage.DisplayAlert("Registration Failed", "Please enter correct entrys", "OK");

            }
        }
    }
}
