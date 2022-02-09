using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Services;
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
            var navService = DependencyService.Get<INavService>();
            BindingContext = new SignUpPageViewModel(DependencyService.Get<INavService>());
            




        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Initialize ViewModel
            ViewModel?.Init();
            
            registerButton.IsEnabled = false;
            
        }

        private void entrytextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(entryFirstname.Text) ||
                string.IsNullOrEmpty(entryLastName.Text) ||
                string.IsNullOrEmpty(entryEmail.Text) ||
                string.IsNullOrEmpty(entryUser.Text)||
                string.IsNullOrEmpty(entryPassword.Text)) registerButton.IsEnabled = false;
            else registerButton.IsEnabled = true;
        }
    }
}