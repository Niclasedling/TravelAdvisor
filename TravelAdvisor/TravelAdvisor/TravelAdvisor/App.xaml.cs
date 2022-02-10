using System;
using System.Net.Http;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.ViewModels;
using TravelAdvisor.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor
{
    public partial class App : Application
    {
        public static AttractionDto globalCurrentAttraction;
        public static UserDto globalUserToComment;
        public static DetailsPageViewModel globalDetailsPageViewModel;
        public static UserPageViewModel globalUserPageViewModel;
        public static ReviewDto globalCurrentReview;
        public static UserDto globalCurrentUser;
        public App()
        {
            InitializeComponent();

            //---------------------------------------------------------Lägg till service
            DependencyService.Register<INavService, NavService>();
            //DependencyService.Register<ILoginService, LoginService>();



            //-------------------------------------------------------Lägg till ApiService

            var userService = new UserService(new HttpClient());
            var forcastService = new OpenWeatherService(new HttpClient());
            var attractionService = new AttractionService(new HttpClient());
            var reviewService = new ReviewService(new HttpClient());
            DependencyService.RegisterSingleton<IUserService>(userService);
            DependencyService.RegisterSingleton<IOpenWeatherService>(forcastService);
            DependencyService.RegisterSingleton<IAttractionService>(attractionService);
            DependencyService.RegisterSingleton<IReviewService>(reviewService);







            //-------------------------------------------------------MainPage är av typen NavigationPage

            MainPage = new NavigationPage(new MainPage());



            //-----------------------------------------------------------------Sätter navigation
            var navService = DependencyService.Get<INavService>();
            navService.SetNavigation(MainPage.Navigation);




        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
