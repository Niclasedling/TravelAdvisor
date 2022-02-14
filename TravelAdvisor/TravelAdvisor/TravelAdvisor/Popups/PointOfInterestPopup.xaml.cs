using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;
using TravelAdvisor.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PointOfInterestPopup : Popup
    {
        private string _address;
        private double _longitude;
        private double _latitude;
        public PointOfInterestPopup(string address, double longitude, double latitude)
        {
            InitializeComponent();
            _address = address;
            _longitude = longitude;
            _latitude = latitude;

        }
        private async void Create_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var userPageViewModel = button.BindingContext as UserPageViewModel;

            var attraction = new AttractionCreateDto
            {
                Name = userPageViewModel.NameOfNewAttraction,
                Details = userPageViewModel.DetailsOfNewAttraction,
                Address = _address,
                Id = Guid.NewGuid(),
                Image = "restaurant.jpg",
                City = userPageViewModel.fetchedForecast,
                Longitude = _longitude,
                Latitude = _latitude,
                Price = 100
            };
          
            var guid = await userPageViewModel._attractionService.CreateAttraction(attraction);
            if(guid == Guid.Empty || guid == null)
            {
                throw new Exception("Guid is empty");
            }
            else
            {
                Dismiss("");
            }
            
            
           
            
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Dismiss("");
        }





    }
}