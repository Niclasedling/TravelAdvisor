using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainPage : ContentPage
    {
        public Attraction Attraction { get; set; }
        MainPageViewModel ViewModel => BindingContext as MainPageViewModel;
        private readonly IUserService _userService;
        public MainPage()
        {
          
            InitializeComponent();
            BindingContext = new MainPageViewModel(DependencyService.Get<INavService>());
            _userService = DependencyService.Get<IUserService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();



            // Initialize ViewModel
            ViewModel?.Init();
        }

        private void SelectType(object sender, EventArgs e)
        {
            var view = sender as View;
            var parent = view.Parent as StackLayout;

            foreach (var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");
        }

        private void ChangeTextColor(View child, string hexColor)
        {
            var txtCtrl = child.FindByName<Label>("PropertyTypeName");
            if (txtCtrl != null)
            {
                txtCtrl.TextColor = Color.FromHex(hexColor);
            }
        }



        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //Guid guid = new Guid("d2ff1305-4b26-45f5-9204-006b01c19067");
            var item = await _userService.GetAllUsers();

            if (item != null)
            {
                var h = item;
            }
            else { }

        }
    }

    

    
}

