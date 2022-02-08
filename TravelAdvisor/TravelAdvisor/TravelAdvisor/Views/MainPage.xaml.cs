using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Interfaces;
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
        public string fetchedForecast;
        public AttractionDto Attraction { get; set; }

        MainPageViewModel ViewModel => BindingContext as MainPageViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(DependencyService.Get<INavService>());
            //_userService = DependencyService.Get<IUserService>();
            //_forcastService = DependencyService.Get<IOpenWeatherService>();
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
            Pin newPin = new Pin
            {
                Position = position,
                Label = "Current Address",
                Address = " ",
                Type = PinType.Place
            };
            //newPin.MarkerClicked += OnMarkerClickedAsync;
            var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);
            map.Pins.Add(newPin);
            await DisplayActionSheet(newPin.Label, "Cancel", "Info", $" Lat : {e.Position.Latitude}\n Long : {e.Position.Longitude}", addresses.FirstOrDefault()?.ToString());
            //await DisplayAlert("Coordinate", $" Lat : {e.Position.Latitude}\n Long : {e.Position.Longitude}", "Ok");
            //var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);


            //await DisplayAlert("Address",
            //    addresses.FirstOrDefault()?.ToString(), "Ok");


        }

       

        private async void searchDestination_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchbar = sender as SearchBar;
            var mainViewModel = searchbar.BindingContext as MainPageViewModel;
            mainViewModel.fetchedForecast = searchDestination.Text;

            mainViewModel.Forecast =  await mainViewModel.GetForecast();
            mainViewModel.cityName = mainViewModel.Forecast.City;
            
        }
    }

    

    
}

