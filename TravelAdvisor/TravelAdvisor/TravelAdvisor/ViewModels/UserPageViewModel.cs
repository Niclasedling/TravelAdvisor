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
        private readonly IReviewService _reviewService;
        public readonly IAttractionService _attractionService;
        public string fetchedForecast;

        public UserPageViewModel(INavService naviService) : base(naviService)
        {
            _userService = DependencyService.Get<IUserService>();
            _forecastService = DependencyService.Get<IOpenWeatherService>();
            _reviewService = DependencyService.Get<IReviewService>();
            _attractionService = DependencyService.Get<IAttractionService>();
        }
        public async override void Init()
        {
            var result = await GetForecast();
            Forecast = result;
            ForecastItems = result.Items;
            cityName = result.City;
            
            App.globalUserToComment = App.globalCurrentUser;
            App.globalUserToComment.FirstName = App.globalCurrentUser.FirstName;
            App.globalUserToComment.LastName = App.globalCurrentUser.LastName;
            UserName = App.globalCurrentUser.UserName;
            
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }
        #region ATTRACTION

        public string NameOfNewAttraction { get; set; }
        public string DetailsOfNewAttraction { get; set; }
        

        public string NameOfAttraction { get { return App.globalCurrentAttraction.Name; } }
        public string InfoAboutAttraction { get { return App.globalCurrentAttraction.Details; } }
        public ImageSource AttractionImgSrc { get { return App.globalCurrentAttraction.Image; } }
        
        public List<AttractionDto> AttractionList => GetAttractions();
        public Command<object> ViewDetails
        {
            get { return new Command<object>(AttractionSelected); }
        }
        async void AttractionSelected(object sender)
        {
            var attraction = sender as AttractionDto;
            if (attraction == null) return;

            App.globalCurrentAttraction = attraction;
            await NavigationService.NavigateTo<DetailsPageViewModel>();

        }


        #endregion

        #region PINS

        public async void SetPins()
        {
            var allAttractions = await _attractionService.GetAllAttractions();

            foreach (var item in allAttractions)
            {

            }
        }



        #endregion

        #region REVIEWS

        public ReviewDto ReviewToAdd { get; set; }
        private string userToComment { get; set; }
        public string UserToComment
        {
            get { return userToComment; }
            set
            {
                userToComment = value;
                OnPropertyChanged("UserToComment");
            }
        }
        public Command<object> GetReviews
        {
            get { return new Command<object>(GetListOfReviews); }
        }
        async void GetListOfReviews(object sender)
        {   

            var user = App.globalCurrentUser;
            if (user == null) return;

            var item = await _reviewService.GetAllReviews();

            
            if (item == null) await App.Current.MainPage.DisplayAlert("Failed", "No Reviews found", "Ok");
            else
            {
                 _listofreviewDtos = item.Select(reviews => reviews).Where(database => database.User.Id == user?.Id).ToList();
                 Reviews = _listofreviewDtos;
            }
            
        }
        
        private List<ReviewDto> _listofreviewDtos { get; set; }
        public List<ReviewDto> Reviews { get { return _listofreviewDtos; } set { _listofreviewDtos = value; OnPropertyChanged("Reviews"); } }
        #endregion


        #region FORECAST

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
        #endregion
       
       
        #region LOGOUT
        public Command<object> LogOutCommand
        {
            get
            {
                return new Command<object>(LogOut);
            }
        }
        async void LogOut(object ojb)
        {
            var answer = await App.Current.MainPage.DisplayActionSheet($"Do you want to logout?", "No", "Yes");
            //var answer = await App.Current.MainPage.DisplayPromptAsync("Loggin out",$"{App.globalCurrentUser.UserName} Do you want to log out?","Yes","No");
            if (answer == "Yes")
            {
                await App.Current.MainPage.DisplayAlert($"Logging out {App.globalCurrentUser.UserName}"," Welcome back", "Ok");
                await NavigationService.NavigateTo<MainPageViewModel>();

            }
        }
        #endregion


        #region MOCKDATA

        public List<Filter> PropertyTypeList => GetFilters();
        private List<Filter> GetFilters()
        {
            return new List<Filter>
            {
                new Filter { Name = "All"},
                new Filter { Name = "Popular"},
            };
        }
        private List<AttractionDto> GetAttractions()
        {
            return new List<AttractionDto>
            {
                new AttractionDto
                {
                    Image = "apt1.jpg",
                    Address = "2162 Patricia Ave, LA",
                    Location = "California",
                    Price = "$1500/month",

                },
                new AttractionDto
                {
                    Image = "apt2.jpg",
                    Address = "2112 Cushions Dr, LA",
                    Location = "California",
                    Price = "$1500/month",

                },
                new AttractionDto
                {
                    Image = "apt3.jpg",
                    Address = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
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
                    Address = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
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
                    Address = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
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
                    Address = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
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
        #endregion
    }
}
