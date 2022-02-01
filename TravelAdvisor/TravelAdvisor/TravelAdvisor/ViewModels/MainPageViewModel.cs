using System;
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
        //public AsyncCommand<object> ViewDetails { get; }
        public Command<object> ViewDetails
        {
            get { return new Command<object>(AttractionSelected); }
        }
        public Command LoginPage => new Command(async () => await NavigationService.NavigateTo<LoginPageViewModel>());
        public Command BackPage => new Command(async () => await NavigationService.GoBack());
        public MainPageViewModel(INavService naviService) : base(naviService)
        {
           
            //Code for creating the ViewModel

        }

        
        
        public override void Init()
        {
            //Code for initialize the ViewModel
        }
        
        

        async void AttractionSelected(object sender)
        {
            var attraction = sender as AttractionDto;
            if (attraction == null) return;

           
            await NavigationService.NavigateTo<DetailsPageViewModel>();

        }
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
                  new AttractionDto
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
                   new AttractionDto
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
