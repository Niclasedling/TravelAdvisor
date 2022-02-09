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

        private readonly Geocoder _geocoder = new Geocoder();

        MainPageViewModel ViewModel => BindingContext as MainPageViewModel;
        CreateAttractionViewModel CreateAttractionViewModel => BindingContext as CreateAttractionViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(DependencyService.Get<INavService>());
            BindingContext = new CreateAttractionViewModel(DependencyService.Get<INavService>());
        }
        
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
                  
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(59.3194903, 18.075060000000007), Distance.FromMeters(15000)));

            ViewModel?.Init();
            CreateAttractionViewModel?.Init();
        }

        //void OnButtonClicked(object sender, EventArgs e)
        //{
        //    Pin boardwalkPin = new Pin
        //    {
        //        Position = new Position(36.9641949, -122.0177232),
        //        Label = "Boardwalk",
        //        Address = "Santa Cruz",
        //        Type = PinType.Place
        //    };
        //    boardwalkPin.MarkerClicked += OnMarkerClickedAsync;

        //    Pin wharfPin = new Pin
        //    {
        //        Position = new Position(36.9571571, -122.0173544),
        //        Label = "Wharf",
        //        Address = "Santa Cruz",
        //        Type = PinType.Place
        //    };
        //    wharfPin.MarkerClicked += OnMarkerClickedAsync;

        //    map.Pins.Add(boardwalkPin);
        //    map.Pins.Add(wharfPin);


        //}


        //async void OnMarkerClickedAsync(object sender, PinClickedEventArgs e)
        //{
        //    //e.HideInfoWindow = true;
        //    string pinName = ((Pin)sender).Label;
        //    await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
            
        //}


        async void map_MapClicked(object sender, MapClickedEventArgs e)
        {

            Position position = new Position(e.Position.Latitude, e.Position.Longitude);

            Pin newPin = new Pin
            {
                Position = position,
                Label = "Current Address",
                Address = " ",
                Type = PinType.Place
            };

            var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);
            var address = addresses.FirstOrDefault();

            var firstanswer = await DisplayActionSheet(address, "Cancel", "Add attraction");


            if (firstanswer == "Cancel")
            {

            }
            else if (firstanswer == "Add attraction") 
            { 
                string nameResult = await DisplayPromptAsync("Name of Attraction", "What's the name of the attraction?");
                string detailsResult = await DisplayPromptAsync("Details of Attraction", "Write a description of the attraction.");

                if (nameResult != null && detailsResult != null)
                {
                    CreateAttractionViewModel.Attraction = new AttractionCreateDto
                    {
                        //Id = new Guid(),
                        Name = nameResult,
                        Details = detailsResult,
                        Image = null,
                        Address = address.Substring(0, 10),
                        Latitude = position.Latitude,
                        Longitude = position.Longitude
                    };
                    await CreateAttractionViewModel.CreateNewAttraction();
                }

            }

            //await DisplayAlert("Address",
            //    addresses.FirstOrDefault()?.ToString(), "Ok");


        }



        private async void searchDestination_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchbar = sender as SearchBar;
            var mainViewModel = searchbar.BindingContext as MainPageViewModel;
            mainViewModel.fetchedForecast = searchDestination.Text;
            
            mainViewModel.AttractionList = await mainViewModel.GetAttractions();
            mainViewModel.Forecast =  await mainViewModel.GetForecast();
            mainViewModel.cityName = mainViewModel.Forecast.City;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(mainViewModel.Forecast.Items[0].Latitude, mainViewModel.Forecast.Items[0].Longitude), Distance.FromMeters(15000)));
        }
    }

    

    
}

