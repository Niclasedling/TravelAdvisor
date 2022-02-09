using System;
using System.Collections.Generic;
using System.Text;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using System.Linq;

namespace TravelAdvisor.ViewModels
{
    public class UserPageViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IOpenWeatherService _forecastService;

        public UserPageViewModel(INavService naviService) : base(naviService)
        {
            _userService = DependencyService.Get<IUserService>();
            _forecastService = DependencyService.Get<IOpenWeatherService>();
        }
        public async override void Init()
        {

            //Code for initialize the ViewModel
            var result = await GetForecast();
            Forecast = result;
            ForecastItems = result.Items;
            cityName = result.City;

        }
        public List<Filter> PropertyTypeList => GetFilters();
        public List<AttractionDto> AttractionList => GetAttractions();
        public Command<object> ViewDetails
        {
            get { return new Command<object>(AttractionSelected); }
        }
        public string fetchedForecast;

        private string _cityName;
        public string cityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                _cityName = value;

                OnPropertyChanged("cityName");
            }
        }
        private Forecast forecast { get; set; }
        public Forecast Forecast
        {
            get
            {
                return forecast;
            }
            set
            {
                forecast = value;
                OnPropertyChanged("Forecast");
            }
        }
        private List<ForecastItem> forecastItems { get; set; }
        public List<ForecastItem> ForecastItems
        {
            get
            {
                return forecastItems;
            }
            set
            {
                forecastItems = value;
                OnPropertyChanged("ForecastItems");
            }
        }
        public async Task<Forecast> GetForecast()
        {

            var forecastAPI = await GetForecastAPI();

            cityName = fetchedForecast;

            Forecast forecast = new Forecast()
            {
                City = forecastAPI.City,
                Items = forecastAPI.Items.Select(y => new ForecastItem
                {
                    Description = y.Description,
                    Icon = $"http://openweathermap.org/img/wn/{y.Icon}@2x.png",
                    Temperature = Math.Round(y.Temperature),
                    WindSpeed = y.WindSpeed,
                    DateTime = y.DateTime,
                    Humidity = y.Humidity,
                    Position = new Xamarin.Forms.Maps.Position(y.Latitude, y.Longitude),
                    Latitude = y.Latitude,
                    Longitude = y.Longitude,


                }).ToList()

            };

            return forecast;
        }

        private async Task<Forecast> GetForecastAPI()
        {
            if (fetchedForecast == null) fetchedForecast = "Stockholm";

            if (fetchedForecast != null)
            {
                return await _forecastService.GetForcast(fetchedForecast);

            }
            else return null;
        }
        private List<Filter> GetFilters()
        {
            return new List<Filter>
            {
                new Filter { Name = "All"},
                new Filter { Name = "Popular"},
            };
        }
        async void AttractionSelected(object sender)
        {
            var attraction = sender as AttractionDto;
            if (attraction == null) return;

            App.globalCurrentAttraction = attraction;
            await NavigationService.NavigateTo<DetailsPageViewModel>();

        }
        private List<AttractionDto> GetAttractions()
        {
            return new List<AttractionDto>
            {
                new AttractionDto
                {
                    Image = "apt1.jpg",
                    Adress = "2162 Patricia Ave, LA",
                    Location = "California",
                    Price = "$1500/month",

                },
                new AttractionDto
                {
                    Image = "apt2.jpg",
                    Adress = "2112 Cushions Dr, LA",
                    Location = "California",
                    Price = "$1500/month",

                },
                new AttractionDto
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                },
                 new AttractionDto
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                },
                  new AttractionDto
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                },
                   new AttractionDto
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                }
            };

        }
    }
}
