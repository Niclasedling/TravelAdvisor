﻿using System;
using System.Net.Http;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor
{
    public partial class App : Application
    {
        public static AttractionDto globalCurrentAttraction;
        public App()
        {
            InitializeComponent();

            //---------------------------------------------------------Lägg till service
            DependencyService.Register<INavService, NavService>();
            //DependencyService.Register<ILoginService, LoginService>();



            //-------------------------------------------------------Lägg till ApiService
            
            var userService = new UserService(new HttpClient());
            var forcastService = new OpenWeatherService(new HttpClient());
            DependencyService.RegisterSingleton<IUserService>(userService);
            DependencyService.RegisterSingleton<IOpenWeatherService>(forcastService);





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
