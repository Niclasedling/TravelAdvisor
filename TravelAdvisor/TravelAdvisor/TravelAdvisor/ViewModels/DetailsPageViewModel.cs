﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using TravelAdvisor.Popups;
using TravelAdvisor.Services;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;

namespace TravelAdvisor.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        public readonly IReviewService _reviewService;
        private readonly IThumbInteractionService _thumbInteractionService;
        //private INavigation _navigation;

        public string TitleOfNewReview { get; set; }
        public string DesciptionOfNewReview { get; set; }
        public int RatingOfNewReview { get; set; }
        public ReviewDto ReviewToAdd { get; set; }
        public string NameOfAttraction { get { return App.globalCurrentAttraction.Name; } }
        public string InfoAboutAttraction { get { return App.globalCurrentAttraction.Details; } }
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
        //public Command AddReview => new Command(async () => await ShowPopup());
        public Command GoBack => new Command(async () => await NavigationService.GoBack());

        public DetailsPageViewModel(INavService naviService) : base(naviService)
        {
            _reviewService = DependencyService.Get<IReviewService>();
            _thumbInteractionService = DependencyService.Get<IThumbInteractionService>();
            //_navigation = navigation;
        }

        public override async void Init()
        {
            
            App.globalUserToComment = new UserDto();
            App.globalUserToComment.FirstName = "";
            App.globalUserToComment.LastName = "";
            ReviewList = await GetReviews();
          
            UserName = App.globalCurrentUser.UserName;
            //var allLikesForCurrentUser = ReviewList
            //    .Select(x => x)
            //    .Where(x => x.User == App.globalCurrentUser)
            //    .Where(x => x.User.HasLikedReview
            //    .ContainsKey(x.Id) && x.User.HasLikedReview
            //    .ContainsValue(true))
            //    .ToList();                                                          //Ska visa hela listan

            //ReviewList.Select(x => x)
                
            //var allDislikesForCurrentUser = ReviewList
            //    .Select(x => x)
            //    .Where(x => x.User == App.globalCurrentUser)
            //    .Where(x => x.User.HasLikedReview
            //    .ContainsKey(x.Id) && x.User.HasLikedReview
            //    .ContainsValue(false))
            //    .ToList();

         
        }

        public List<ReviewDto> reviewList { get; set; }
        public List<ReviewDto> ReviewList { get { return reviewList; } set { reviewList = value; OnPropertyChanged("ReviewList"); } }

        public List<ThumbInteractionDto> likeList { get; set; }
        public List<ThumbInteractionDto> LikeList { get { return likeList; } set { likeList = value; OnPropertyChanged("LikeList"); } }

        private async Task<List<ReviewDto>> GetReviews()
        {

            var reviews = await _reviewService.GetListById(App.globalCurrentAttraction.Id);

            if (reviews != null)
            {
                return reviews;


            }

            return null;
        }
     public async Task<List<ThumbInteractionDto>> GetLikes()
        {

            var likes = await _thumbInteractionService.GetById(App.globalCurrentReview.Id);

            if (likes != null)
            {
                return likes;
            }

            return null;
        }



        //private async Task ShowPopup()
        //{

        //    await _navigation.ShowPopupAsync(new NewReviewPopup());
        //}
    }
}
