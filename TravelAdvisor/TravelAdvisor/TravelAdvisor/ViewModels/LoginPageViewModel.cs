using System;
using System.Collections.Generic;
using System.Text;
using TravelAdvisor.Services;

namespace TravelAdvisor.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        //public Command ViewDetails => new Command(async () => await NavigationService.NavigateTo<DetailsPageViewModel>());

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
