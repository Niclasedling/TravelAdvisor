using System;
using System.Collections.Generic;
using System.Text;
using TravelAdvisor.Services;
using TravelAdvisor.Views;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        readonly LoginPage loginPage = new LoginPage();
        //public Command ViewDetails => new Command(async () => await NavigationService.NavigateTo<DetailsPageViewModel>());
        public Command BackPage => new Command(async () => await NavigationService.GoBack());
        
        public LoginPageViewModel(INavService naviService) : base(naviService)
        {
            //Code for creating the ViewModel
            
        }

        public override void Init()
        {
            //Code for initialize the ViewModel
        }
    }
}
