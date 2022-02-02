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
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public AttractionDto Attraction { get; set; }
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

        void OnButtonClicked(object sender, EventArgs e)
        {
            Pin boardwalkPin = new Pin
             {
                 Position = new Position(36.9641949, -122.0177232),
                 Label = "Boardwalk",
                 Address = "Santa Cruz",
                 Type = PinType.Place
             };
             boardwalkPin.MarkerClicked += OnMarkerClickedAsync;

             Pin wharfPin = new Pin
             {
                 Position = new Position(36.9571571, -122.0173544),
                 Label = "Wharf",
                 Address = "Santa Cruz",
                 Type = PinType.Place
             };
             wharfPin.MarkerClicked += OnMarkerClickedAsync;

             map.Pins.Add(boardwalkPin);
             map.Pins.Add(wharfPin);
            

        }


        async void OnMarkerClickedAsync(object sender, PinClickedEventArgs e)
        {
            //e.HideInfoWindow = true;
            string pinName = ((Pin)sender).Label;
            await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
        }

        private readonly Geocoder _geocoder = new Geocoder();

        async void map_MapClicked(object sender, MapClickedEventArgs e)
        {
            //Pin newPIn = new Pin
            //{
            Position position = new Position(e.Position.Latitude, e.Position.Longitude);
            //};
            await DisplayAlert("Coordinate", $" Lat {e.Position.Latitude}, Long {e.Position.Longitude}", "Ok");
            var addresses = await _geocoder.GetAddressesForPositionAsync(position);

            

            await DisplayAlert("Addresses", addresses.FirstOrDefault()?.ToString(), "Ok");

            
            


        }
        







        //private void SelectType(object sender, EventArgs e)
        //{
        //    var view = sender as View;
        //    var parent = view.Parent as StackLayout;

        //    foreach (var child in parent.Children)
        //    {
        //        VisualStateManager.GoToState(child, "Normal");
        //        ChangeTextColor(child, "#707070");
        //    }

        //    VisualStateManager.GoToState(view, "Selected");
        //    ChangeTextColor(view, "#FFFFFF");
        //}

        //private void ChangeTextColor(View child, string hexColor)
        //{
        //    var txtCtrl = child.FindByName<Label>("PropertyTypeName");
        //    if (txtCtrl != null)
        //    {
        //        txtCtrl.TextColor = Color.FromHex(hexColor);
        //    }
        //}



        //private async void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    UserCreateDto user = new UserCreateDto
        //    { 
        //      FirstName = "Alexander",
        //      LastName = "Andersson",
        //      Email = "1234@hotmail.com",
        //      Password = "1234"
        //    };
        //    var item = await _userService.CreateUser(user);
        //    //Guid guid = new Guid("d2ff1305-4b26-45f5-9204-006b01c19067");
        //    //var item = await _userService.GetAllUsers();

        //    if (item != null)
        //    {
        //        var h = item;
        //    }
        //    else { }

        //}
    }

    

    
}

