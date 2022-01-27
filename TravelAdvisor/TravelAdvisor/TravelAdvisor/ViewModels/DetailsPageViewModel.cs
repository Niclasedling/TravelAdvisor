using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        
        public Command GoBack => new Command(async () => await NavigationService.GoBack());
        public DetailsPageViewModel(INavService naviService, AttractionDto attraction) : base(naviService)
        {
            //Code for creating the ViewModel
            
            

        }

        public override void Init()
        {
            //Code for initialize the ViewModel
            
        }
    }
}
