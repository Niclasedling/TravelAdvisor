using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        DetailsPageViewModel ViewModel => BindingContext as DetailsPageViewModel;
        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = new DetailsPageViewModel(DependencyService.Get<INavService>(), App.globalAttraction);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
            // Initialize ViewModel
            ViewModel?.Init();
        }
    }
}