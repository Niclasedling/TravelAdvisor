using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {

        

        public Command GoBack => new Command(async () => await NavigationService.GoBack());
        


        public DetailsPageViewModel(INavService naviService, AttractionDto attraction) : base(naviService)
        {
            //Code for creating the ViewModel
            
           

        }

        public override void Init()
        {
            //Code for initialize the ViewModel
            
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
                    Id = Guid.NewGuid(),
                    Image = "apt1.jpg",
                    Adress = "2162 Patricia Ave, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Details = "First picture"


                },
                new AttractionDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt2.jpg",
                    Adress = "2112 Cushions Dr, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Details = "Second picture"

                },
                new AttractionDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Details = "Third picture"
                },
                 new AttractionDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Details = "Fourth picture"
                },
                  new AttractionDto
                {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
