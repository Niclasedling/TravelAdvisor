﻿using System;
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
        }

        async void AttractionSelected(object sender)
        {
            var attraction = sender as AttractionDto;
            if (attraction == null) return;


            await NavigationService.NavigateTo<DetailsPageViewModel>();

        }

        private async Task<Forecast> GetForecast()
        {
            var forecastAPI = await GetForecastAPI();

            Forecast forecast = new Forecast()
            {
                City = forecastAPI.City,
                Items = forecastAPI.Items.Select(y => new ForecastItem
                {
                    Description = y.Description,
                    Icon = y.Icon,
                    Temperature = y.Temperature,
                    WindSpeed = y.WindSpeed,
                }).ToList()

            };

            return forecast;
        }
        private async Task<Forecast> GetForecastAPI()
        {
            fetchedForecast = "Stockholm";
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
                    
                },
                 new AttractionDto
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                   
                },
                  new AttractionDto
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    
                },
                   new AttractionDto
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    
                }
            };
        }
    }
}
