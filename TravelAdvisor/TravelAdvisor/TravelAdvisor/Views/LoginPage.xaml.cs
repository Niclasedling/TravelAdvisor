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
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel ViewModel => BindingContext as LoginPageViewModel;

        public LoginPage()
        {
            InitializeComponent();
            var navService = DependencyService.Get<INavService>();
            BindingContext = new LoginPageViewModel(DependencyService.Get<INavService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialize ViewModel
            ViewModel?.Init();
        }

       

        private void Login_Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}