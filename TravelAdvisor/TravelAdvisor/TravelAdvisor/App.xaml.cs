using System;
using TravelAdvisor.Services;
using TravelAdvisor.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<INavService,NavService>();
            //Registerar service
         
            MainPage = new NavigationPage(new MainPage());
            //MainPage är av typen NavigationPage
            

            var navService = DependencyService.Get<INavService>();
            navService.SetNavigation(MainPage.Navigation);
            //Sätter navigation



            //MainPage = new NavigationPage(new LoginPage());
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
