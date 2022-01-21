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

namespace TravelAdvisor.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel ViewModel => BindingContext as MainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            var navService = DependencyService.Get<INavService>();
            BindingContext = new MainPageViewModel(DependencyService.Get<INavService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialize ViewModel
            ViewModel?.Init();
        }

       

        //private async void AttractionSelected(object sender, EventArgs e)
        //{
        //    var attraction = (sender as View).BindingContext as Attraction;
        //    await this.Navigation.PushAsync(new DetailsPage(attraction));
        //}

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
    }

    

    
}

