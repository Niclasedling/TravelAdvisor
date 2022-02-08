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
        DetailsPageViewModel _detailsPageView { get { return new DetailsPageViewModel(DependencyService.Get<INavService>());} }
       
        public string NameOfAttraction { get { return App.globalCurrentAttraction.Name; } }
        public string InfoAboutAttraction { get { return App.globalCurrentAttraction.Description; } }
        public ImageSource AttractionImgSrc { get { return App.globalCurrentAttraction.Image; } }
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
        
        public Command GoBack => new Command(async () => await NavigationService.GoBack());
        

        public DetailsPageViewModel(INavService naviService) : base(naviService)
        {
            //Code for creating the ViewModel
            
            
          

        }

        

        public override void Init()
        {
            //Code for initialize the ViewModel
            
            App.globalDetailsPageViewModel = _detailsPageView;
            App.globalUserToComment = new UserDto();
            App.globalUserToComment.FirstName = "";
            App.globalUserToComment.LastName = "";

        }
        public List<ReviewDto> Reviews { get { return App.globalCurrentAttraction.Reviews = GetReviews(); } }


        //public List<ReviewDto> RealReviews { get { return } }
        //public List<ReviewDto> ReviewList => GetReviews();

        //public void ButtonClicked()
        //{
        //    OnPropertyChanged(nameof(ButtonClicked));   
        //}

        public List<UserCommentDto> UserComments => GetUserComments();
        
        private List<UserCommentDto> GetUserComments()
        {
            return new List<UserCommentDto>
            {
                new UserCommentDto
                {
                    Comment = "A really cool place! I recommend strongly!",
                },
                new UserCommentDto
            {
                Comment = "Nice beverages and nice food for an afforable price! Recommend!",
            },
            new UserCommentDto
            {
                Comment = "Superior service!",
            },
            new UserCommentDto
            {
                Comment = "Amazing food and an amazing view!",
            },
            new UserCommentDto
            {
                Comment = "Good food and nice service!",
            },
            new UserCommentDto
            {
                Comment = "Fun activities for everyone! Really recommend!",
            }
            };
        }


        private List<ReviewDto> GetReviews()
        {
            
            return new List<ReviewDto>
            {
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",                                  
                    User = new UserDto
                    {
                        FirstName = "Mario", 
                        LastName = "Wade",
                        Review = "First picture",
                       
                    }


                },
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",                   
                    User = new UserDto
                    {
                        FirstName = "Sannah", 
                        LastName = "Carter",
                        Review = "Second picture",
                    }


                },
                new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",
                   
                    User = new UserDto
                    {
                        FirstName = "Daniel", 
                        LastName = "Morton", 
                        Review = "Third picture",
                    }
                },
                 new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",
                   
                    User = new UserDto
                    {
                        FirstName = "Haaris", 
                        LastName = "Spears", 
                        Review = "Fourth picture",
                    }
                },
                  new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",
                    User = new UserDto
                    {
                        FirstName = "Johanna", 
                        LastName = "Krause",
                        Review = "Fifth picture",
                    }
                },
                   new ReviewDto
                {
                    Id = Guid.NewGuid(),
                    Image = "user.png",                
                    User = new UserDto
                    {
                        FirstName = "Anita", 
                        LastName = "Hartley",
                        Review = "¨Sixth picture",
                    }
                }
            };
        }
    }
}
