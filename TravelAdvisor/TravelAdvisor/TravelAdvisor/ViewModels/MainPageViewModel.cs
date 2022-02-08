using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IOpenWeatherService _forecastService;
        public MainPageViewModel _mainPageViewModel;
       
        public MainPage MainPageProperty { get; set; }

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
        //public AsyncCommand<object> ViewDetails { get; }
        public Command<object> ViewDetails
        {
            get { return new Command<object>(AttractionSelected); }
        }
        public Command LoginPage => new Command(async () => await NavigationService.NavigateTo<LoginPageViewModel>());
        public Command BackPage => new Command(async () => await NavigationService.GoBack());

        public List<Filter> PropertyTypeList => GetFilters();
        public List<AttractionDto> AttractionList => GetAttractions();
        private List<Filter> GetFilters()
        {
            return new List<Filter>
            {
                new Filter { Name = "All"},
                new Filter { Name = "Popular"},
            };
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

        public MainPageViewModel(INavService naviService) : base(naviService)
        {
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

        async void AttractionSelected(object sender)
        {
            var attraction = sender as AttractionDto;
            if (attraction == null) return;

            App.globalCurrentAttraction = attraction;
            await NavigationService.NavigateTo<DetailsPageViewModel>();

        }

        public async Task<Forecast> GetForecast()
        {
            var forecastAPI = await GetForecastAPI();

            _cityName = fetchedForecast;

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
                    Longitude = y.Longitude,
                    Latitude = y.Latitude,

                }).ToList()

            };

            return forecast;
        }
        private async Task<Forecast> GetForecastAPI()
        {
            if(fetchedForecast == null) fetchedForecast = "Stockholm";

            if (fetchedForecast != null)
            {
                return await _forecastService.GetForcast(fetchedForecast);

            }
            else return null;
        }
        private List<AttractionDto> GetAttractions()
        {
            return new List<AttractionDto>
            {
                new AttractionDto
                {
                    Name = "First attraction",
                    Image = "apt1.jpg",
                    Adress = "2162 Patricia Ave, LA",
                    Location = "California",
                    Description = "Some description"
                    
                },
                new AttractionDto
                {
                    Name = "Second attraction",
                    Image = "apt2.jpg",
                    Adress = "2112 Cushions Dr, LA",
                    Location = "California",
                    Description = "Some description"

                },
                new AttractionDto
                {
                    Name = "Third attraction",
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Description = "Some description"

                },
                 new AttractionDto
                {
                    Name = "Fourth attraction",
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Description = "Some description"

                },
                  new AttractionDto
                {
                    Name = "Fifth attraction",
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Description = "Some description"

                },
                   new AttractionDto
                {
                    Name = "Sixth attraction",
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Description = "Some description"

                }
            };
        }
    }
}
