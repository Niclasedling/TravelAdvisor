using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {

        SignUpPageViewModel ViewModel => BindingContext as SignUpPageViewModel;

        public SignUpPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialize ViewModel
            ViewModel?.Init();
        }
    }
}