﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPage MainPageProperty { get; set; }
        public AsyncCommand<object> ViewDetails { get; }
        public Command LoginPage => new Command(async () => await NavigationService.NavigateTo<LoginPageViewModel>());
        public Command BackPage => new Command(async () => await NavigationService.GoBack());
        public MainPageViewModel(INavService naviService) : base(naviService)
        {
            //Code for creating the ViewModel
            ViewDetails = new AsyncCommand<object>(AttractionSelected);
        }

        public override void Init()
        {
            //Code for initialize the ViewModel
        }
        //private void AttractionSelected(object sender, EventArgs e)
        //{
        //    var attraction = (sender as View).BindingContext as Attraction;
            
        //}

        async Task AttractionSelected(object sender)
        {
            var attraction = sender as Attraction;
            if (attraction == null) return;

            await NavigationService.NavigateTo<DetailsPageViewModel>();

        }
        public List<Filter> PropertyTypeList => GetFilters();
        public List<Attraction> PropertyList => GetAttractions();

        private List<Filter> GetFilters()
        {
            return new List<Filter>
            {
                new Filter { Name = "All"},
                new Filter { Name = "Popular"},
            };
        }

        private List<Attraction> GetAttractions()
        {
            return new List<Attraction>
            {
                new Attraction
                {
                    Image = "apt1.jpg",
                    Adress = "2162 Patricia Ave, LA",
                    Location = "California",
                    Price = "$1500/month",
                    
                },
                new Attraction
                {
                    Image = "apt2.jpg",
                    Adress = "2112 Cushions Dr, LA",
                    Location = "California",
                    Price = "$1500/month",
                  
                },
                new Attraction
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
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
                 new Attraction
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
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
                  new Attraction
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
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
                   new Attraction
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
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
    }
}
