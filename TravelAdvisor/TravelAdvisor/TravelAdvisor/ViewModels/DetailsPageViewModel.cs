using System;
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
        public readonly IThumbInteractionService _thumbInteractionService;
        public readonly ICommentService _commentService;
        
        //private INavigation _navigation;

        public string TitleOfNewReview { get; set; }
        public string DesciptionOfNewReview { get; set; }
        public int RatingOfNewReview { get; set; }
        public ReviewDto ReviewToAdd { get; set; }
        public ReviewDto CurrentReview { get; set; }
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
            _commentService = DependencyService.Get<ICommentService>();
            _thumbInteractionService = DependencyService.Get<IThumbInteractionService>();
            //_navigation = navigation;
        }

        public override async void Init()
        {       
            App.globalUserToComment = new UserDto();
            App.globalUserToComment.FirstName = "";
            App.globalUserToComment.LastName = "";
            await RefreshValues();
            

            UserName = App.globalCurrentUser.UserName;       
        }

        public List<ReviewDto> reviewList { get; set; }
        public List<ReviewDto> ReviewList { get { return reviewList; } set { reviewList = value; OnPropertyChanged("ReviewList"); } }

        public ThumbInteractionDto userThumbInteraction { get; set; }
        public ThumbInteractionDto UserThumbInteraction { get { return userThumbInteraction; } set { userThumbInteraction = value; OnPropertyChanged("UserThumbInteraction"); } }
        public List<ThumbInteractionDto> likeList { get; set; }
        public List<ThumbInteractionDto> LikeList { get { return likeList; } set { likeList = value; OnPropertyChanged("LikeList"); } }

        private async Task<List<ReviewDto>> GetReviews()
        {

            var reviews = await _reviewService.GetListById(App.globalCurrentAttraction.Id);

            foreach (var item in reviews)
            {
                switch (item.Rating)
                {
                    case 0:
                        item.OneStar = item.WhiteStar;
                        item.TwoStars = item.WhiteStar;
                        item.ThreeStars = item.WhiteStar;
                        item.FourStars = item.WhiteStar;
                        item.FiveStars = item.WhiteStar;
                        break;
                    case 1:
                        item.OneStar = item.YellowStar;
                        item.TwoStars = item.WhiteStar;
                        item.ThreeStars = item.WhiteStar;
                        item.FourStars = item.WhiteStar;
                        item.FiveStars = item.WhiteStar;
                        break;
                    case 2:
                        item.OneStar = item.YellowStar;
                        item.TwoStars = item.YellowStar;
                        item.ThreeStars = item.WhiteStar;
                        item.FourStars = item.WhiteStar;
                        item.FiveStars = item.WhiteStar;
                        break;
                    case 3:
                        item.OneStar = item.YellowStar;
                        item.TwoStars = item.YellowStar;
                        item.ThreeStars = item.YellowStar;
                        item.FourStars = item.WhiteStar;
                        item.FiveStars = item.WhiteStar;
                        break;
                    case 4:
                        item.OneStar = item.YellowStar;
                        item.TwoStars = item.YellowStar;
                        item.ThreeStars = item.YellowStar;
                        item.FourStars = item.YellowStar;
                        item.FiveStars = item.WhiteStar;
                        break;
                    case 5:
                        item.OneStar = item.YellowStar;
                        item.TwoStars = item.YellowStar;
                        item.ThreeStars = item.YellowStar;
                        item.FourStars = item.YellowStar;
                        item.FiveStars = item.YellowStar;
                        break;
                   
                }
            }


            if (reviews != null)
            {
                return reviews;


            }

            return null;
        }
        public async Task<List<CommentDto>> GetAllComments()
        {
            var comments = await _commentService.GetAll();

            
            return comments;
            

            
        }
        public async Task<List<ThumbInteractionDto>> GetAllThumbInteractions()
        {
            var thumbInteractions = await _thumbInteractionService.GetList();

            if (thumbInteractions != null)
            {
                return thumbInteractions;
            }

            return null;
        }
        public async Task<List<ThumbInteractionDto>> GetThumbInteractionsByReview()
        {

            var likes = await _thumbInteractionService.GetById(App.globalCurrentReview.Id);

            if (likes != null)
            {
                return likes;
            }

            return null;
        }
        public async Task<List<ThumbInteractionDto>> GetThumbInteractionByUser()
        {
            var response = await _thumbInteractionService.GetByUserId(App.globalCurrentUser.Id);

            if (response != null)
            {
                return response;
            }

            return null;
        }
        public async Task<Guid> CreateThumbInteraction(ThumbInteractionCreateDto newThumbInteraction)
        {
            return await _thumbInteractionService.Create(newThumbInteraction);
        }

        public async Task<bool> UpdateThumbInteraction(ThumbInteractionUpdateDto thumbInteractionUpdateDto)
        {
            return await _thumbInteractionService.Update(thumbInteractionUpdateDto);
        }
        public async Task<bool> DeleteThumbInteraction(Guid id)
        {
            return await _thumbInteractionService.Delete(id);
        }

       //public async Task CalculateAverageRating()
       // {

       // }
     
       public async Task RefreshValues()
        {
            ReviewList = await GetReviews();
            var comments = await GetAllComments();
            var thumbInteractions = await GetAllThumbInteractions();

            foreach (var review in ReviewList)
            {
                foreach (var comment in comments)
                {
                    if (comment.ReviewId == review.Id)
                    {
                        review.CommentList.Add(comment);
                    }
                }
                if(thumbInteractions.Count != 0)
                {

                
                foreach (var thumbInteraction in thumbInteractions)
                {
                    if (thumbInteraction.ReviewId == review.Id && thumbInteraction.UserId == App.globalCurrentUser.Id)
                    {
                        //review.ThumbInteraction = thumbInteraction;

                        if (thumbInteraction.HasLiked)
                        {
                            review.LikeThumbImgSrc = review.LikeThumbGreenImgSrc;
                            review.DislikeThumbImgSrc = review.DislikeThumbDefault;
                        }
                        else if(!thumbInteraction.HasLiked)
                        {
                            review.DislikeThumbImgSrc = review.DislikeThumbRedImgSrc;
                            review.LikeThumbImgSrc = review.LikeThumbDefault;
                        }
                        else
                        {
                            review.LikeThumbImgSrc = review.LikeThumbDefault;
                            review.DislikeThumbImgSrc = review.DislikeThumbDefault;
                        }

                            CurrentReview = review;
                    }
                        //else if (thumbInteraction.UserId == App.globalCurrentUser.Id)
                        //{
                        //    if (thumbInteraction.HasLiked)
                        //    {
                        //        review.LikeThumbImgSrc = review.LikeThumbGreenImgSrc;
                        //        review.DislikeThumbImgSrc = review.DislikeThumbDefault;
                        //    }
                        //    else if (!thumbInteraction.HasLiked)
                        //    {
                        //        review.DislikeThumbImgSrc = review.DislikeThumbRedImgSrc;
                        //        review.LikeThumbImgSrc = review.LikeThumbDefault;
                        //    }
                        //    else
                        //    {
                        //        review.LikeThumbImgSrc = review.LikeThumbDefault;
                        //        review.DislikeThumbImgSrc = review.DislikeThumbDefault;
                        //    }

                        //}

                        else
                        {
                            
                            review.LikeThumbImgSrc = review.LikeThumbDefault;
                            review.DislikeThumbImgSrc = review.DislikeThumbDefault;
                        }


                    }
                }
                else
                {
                    review.LikeThumbImgSrc = review.LikeThumbDefault;
                    review.DislikeThumbImgSrc = review.DislikeThumbDefault;
                }

            }
        } 
    }
}
