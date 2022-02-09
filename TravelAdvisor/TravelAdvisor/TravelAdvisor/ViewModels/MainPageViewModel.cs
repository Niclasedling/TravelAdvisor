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
        private readonly IAttractionService _attractionService;
        private readonly IOpenWeatherService _forecastService;



        public MainPageViewModel _mainPageViewModel;
        public MainPage MainPageProperty { get; set; }

        public string fetchedForecast;
        
        private string _cityName;
        public string cityName 
        { 
            get { return _cityName; }
            set
            {
                _cityName = value;
                OnPropertyChanged("cityName");
            }
        }
        public Command<object> ViewDetails
        {
            get { return new Command<object>(AttractionSelected); }
        }
        public Command LoginPage => new Command(async () => await NavigationService.NavigateTo<LoginPageViewModel>());
        public Command BackPage => new Command(async () => await NavigationService.GoBack());

        public List<Filter> PropertyTypeList => GetFilters();
        public List<AttractionDto> attractionList { get; set; }
        public List<AttractionDto> AttractionList { get { return attractionList; } set { attractionList = value; OnPropertyChanged("AttractionList"); } }
       
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
            get { return forecastItems; }
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
            _attractionService = DependencyService.Get<IAttractionService>();
        }
        public void InitializePosition()
        {
            
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
            if(fetchedForecast == null) fetchedForecast = "Stockholm";

            if (fetchedForecast != null)
            {
                return await _forecastService.GetForcast(fetchedForecast);

            }
            else return null;
        }
        public async Task<List<AttractionDto>> GetAttractions()
        {

            var attractions = await _attractionService.GetAllAttractionsByCity(fetchedForecast);
            if (attractions != null)
            {
                return attractions;
            }
            return null;
        }
    }
}
