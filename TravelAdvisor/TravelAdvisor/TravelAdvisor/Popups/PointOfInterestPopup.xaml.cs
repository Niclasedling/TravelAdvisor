using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;
using TravelAdvisor.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PointOfInterestPopup : Popup
    {
        private string _address;
        private double _longitude;
        private double _latitude;
        private Position _position;
        private string _imageSelected;
        public PointOfInterestPopup(string address, double longitude, double latitude, Position position)
        {
            InitializeComponent();
            _address = address;
            _longitude = longitude;
            _latitude = latitude;
            _position = position;

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
                Image = _imageSelected,
                City = userPageViewModel.fetchedForecast,
                Longitude = _longitude,
                Latitude = _latitude,
                Position = _position,
                Price = 100
            };
          
            var guid = await userPageViewModel._attractionService.CreateAttraction(attraction);
            if(guid == Guid.Empty || guid == null)
            {
                throw new Exception("Guid is empty");
            }
            else
            {
                userPageViewModel.AttractionList = await userPageViewModel._attractionService.GetAllAttractionsByCity(userPageViewModel.fetchedForecast);
                Dismiss(attraction);
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Dismiss("");
        }

        private void TypeOfAttraction_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            switch (radioButton.Content)
            {
                case "Restaurant":
                    _imageSelected = "newrestaurant.jpg";
                    break;
                case "Store":
                    _imageSelected = "store.jpg";
                    break;
                case "Nature Area":
                    _imageSelected = "nature-area.jpg";
                    break;
                
            }
        }



    }
}