using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Services;
using TravelAdvisor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;


namespace TravelAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        UserPageViewModel ViewModel => BindingContext as UserPageViewModel;
        Geocoder _geocoder;
        public UserPage()
        {
            InitializeComponent();
            _geocoder = new Geocoder();
            BindingContext = new UserPageViewModel(DependencyService.Get<INavService>());
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

        private async void map_MapClicked(object sender, MapClickedEventArgs e)
        {
            Position position = e.Position;
            await DisplayAlert("Coordiantes", $"Lat: {e.Position.Latitude}, Long {e.Position.Longitude}", "Ok");

            var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);


            await DisplayAlert("Adress", addresses.FirstOrDefault()?.ToString(), "Ok");
        }
    }
}