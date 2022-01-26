using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        readonly LoginService loginService;

        public AsyncCommand<object> LoginCommand { get; }
        public Command BackPage => new Command(async () => await NavigationService.GoBack());
        public Command SignUpPage => new Command(async () => await NavigationService.NavigateTo<SignUpPageViewModel>());

        public LoginPageViewModel(INavService naviService) : base(naviService)
        {

            if(LoginCommand != null)
            {
                LoginCommand = new AsyncCommand<object>(Login);
            }
        }


        public override void Init()
        {
            //Code for initialize the ViewModel
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;

            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;

            }
        }
        //public AsyncCommand LoginCommand
        //{
        //    get
        //    {
        //        return new AsyncCommand(await loginService.Login(Email, Password));
        //    }
        //}

        async Task Login(object sender)
        {
            await loginService.Login(Email, Password);


        }
    }
}
