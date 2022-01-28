using System;
using System.Collections.Generic;
using System.Text;
using TravelAdvisor.Services;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class UserPageViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        public UserPageViewModel(INavService naviService) : base(naviService)
        {
            _userService = DependencyService.Get<IUserService>();
        }
        public override void Init()
        {

            //Code for initialize the ViewModel
        }
    }
}
