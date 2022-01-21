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
       
        //public Command ViewDetails => new Command(async () => await NavigationService.NavigateTo<DetailsPageViewModel>());
        public Command BackPage => new Command(async () => await NavigationService.GoBack());
        public Command SignUpPage => new Command(async () => await NavigationService.NavigateTo<SignUpPageViewModel>());

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
