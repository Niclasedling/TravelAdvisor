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

        public string NameOfAttraction { get { return App.globalCurrentAttraction.Name; } }
        public string InfoAboutAttraction { get { return App.globalCurrentAttraction.Description; } }
        public ImageSource AttractionImgSrc { get { return App.globalCurrentAttraction.Image; } }
        public Command GoBack => new Command(async () => await NavigationService.GoBack());
        


        public DetailsPageViewModel(INavService naviService, AttractionDto attraction) : base(naviService)
        {
            //Code for creating the ViewModel
            
          

        }

        public override void Init()
        {
            //Code for initialize the ViewModel
             
        }
        public List<ReviewDto> Reviews { get { return App.globalCurrentAttraction.Reviews = GetReviews(); } }
        //public List<ReviewDto> ReviewList => GetReviews();
        
       
        private List<ReviewDto> GetReviews()
        {
            
            return new List<ReviewDto>
            {
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",                 
                    Comment = "First picture",
                    User = new UserDto{FirstName = "Mario", LastName = "Wade"}


                },
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",
                    Comment = "Second picture",
                    User = new UserDto{FirstName = "Sannah", LastName = "Carter"}

                },
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",
                    Comment = "Third picture",
                    User = new UserDto{FirstName = "Daniel", LastName = "Morton"}
                },
                 new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",
                    Comment = "Fourth picture",
                    User = new UserDto{FirstName = "Haaris", LastName = "Spears"}
                },
                  new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",
                    Comment = "Fifth picture",
                    User = new UserDto{FirstName = "Johanna", LastName = "Krause"}
                },
                   new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",
                    Comment = "Sixth picture",
                    User = new UserDto{FirstName = "Anita", LastName = "Hartley"}
                }
            };
        }
    }
}
