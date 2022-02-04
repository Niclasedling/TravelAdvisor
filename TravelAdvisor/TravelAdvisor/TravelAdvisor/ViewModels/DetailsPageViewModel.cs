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

        public List<ReviewDto> ReviewList => GetReviews();

        private List<ReviewDto> GetReviews()
        {
            return new List<ReviewDto>
            {
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt1.jpg",                 
                    Comment = "First picture",
                    User = new UserDto{FirstName = "Mario", LastName = "Wade"}


                },
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt2.jpg",
                    Comment = "Second picture",
                    User = new UserDto{FirstName = "Sannah", LastName = "Carter"}

                },
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt3.jpg",
                    Comment = "Third picture",
                    User = new UserDto{FirstName = "Daniel", LastName = "Morton"}
                },
                 new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt3.jpg",
                    Comment = "Fourth picture",
                    User = new UserDto{FirstName = "Haaris", LastName = "Spears"}
                },
                  new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt3.jpg",
                    Comment = "Fifth picture",
                    User = new UserDto{FirstName = "Johanna", LastName = "Krause"}
                },
                   new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "apt3.jpg",
                    Comment = "Sixth picture",
                    User = new UserDto{FirstName = "Anita", LastName = "Hartley"}
                }
            };
        }
    }
}
