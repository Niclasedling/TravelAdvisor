using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {

        private readonly ILoginService _loginService;
        private readonly IUserService _userService;
        private readonly INavService _navService;
        public Command<object> LoginCommand
        { 
            get
            {
                return new Command<object>(Login); 
            }
        }
        public Command BackPage => new Command(async () => await NavigationService.GoBack());
        public Command SignUpPage => new Command(async () => await NavigationService.NavigateTo<SignUpPageViewModel>());

        public LoginPageViewModel(INavService naviService) : base(naviService)
        {
            _loginService = DependencyService.Get<ILoginService>();
            _userService = DependencyService.Get<IUserService>();
            _navService = DependencyService.Get<INavService>();
            //if (LoginCommand != null)
            //{
            //    LoginCommand = new AsyncCommand<object>(Login);
            //}
        }


        public override void Init()
        {
            //Code for initialize the ViewModel
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        //private void Login()
        //{
        //    //null or empty field validation, check weather email and password is null or empty  
        //    if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        //        App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
        //    else
        //    {
        //        if (Email == "abc@gmail.com" && Password == "1234")
        //        {
        //            App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
        //            //Navigate to Wellcom page after successfully login  
        //            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        //        }
        //        else
        //            App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
        //    }
        //}
        async void Login(object sender)
        {
            UserLoginDto user = new UserLoginDto
            {
                Email = Email,
                Password = Password
            };
           
            if (await _userService.Login(user))
            {
                await App.Current.MainPage.DisplayAlert("Login Success", $"Welcome {user.Email}", "Ok");
                await _navService.NavigateTo<UserPageViewModel>();
            }
            else await App.Current.MainPage.DisplayAlert("Login Failed","Email or Password incorrect", "Ok");
        }
    }
}
