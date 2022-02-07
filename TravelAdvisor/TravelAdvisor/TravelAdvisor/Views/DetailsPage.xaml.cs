using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        AttractionDto attraction = new AttractionDto();
        DetailsPageViewModel ViewModel => BindingContext as DetailsPageViewModel;
        public DetailsPage()
        {
            
            InitializeComponent();
            
            BindingContext = new DetailsPageViewModel(DependencyService.Get<INavService>(), attraction);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Initialize ViewModel
            
            ViewModel?.Init();
            
            
        }

        private void LikeThumb_Clicked(object sender, EventArgs e)
        {
            var likeButton = sender as ImageButton;
            var review = likeButton.BindingContext as ReviewDto;

            review.LikeButton = likeButton;
            if (review.LikeButton == null) return;

            if(!review.ThumbIsGreen || review.ThumbStringToCompare == null)
            {
                
                if (!review.User.HasLiked)
                {
                    review.TotalLikes++;
                    review.User.HasLiked = true;
                }

                if (review.User.HasDisliked)
                {
                    review.TotalDislikes--;
                    review.User.HasDisliked = false;
                }


                review.LikeButton.Source = review.LikeThumbGreenImgSrc;
                review.DislikeButton.Source = review.DislikeThumbImgSrc;
                review.ThumbIsGreen = true;
                review.ThumbIsRed = false;

                review.ThumbStringToCompare = review.LikeThumbGreenString;
            }
            else
            {
                review.User.HasLiked = false;
                review.TotalLikes--;
                review.LikeButton.Source = review.LikeThumbImgSrc;
                review.ThumbIsGreen = false;
                review.ThumbStringToCompare = review.LikeThumbString;
                
                
            }
        }

        private void DislikeThumb_Clicked(object sender, EventArgs e)
        {
            var dislikeButton = sender as ImageButton;
            var review = dislikeButton.BindingContext as ReviewDto;

            review.DislikeButton = dislikeButton;

            if (review.DislikeButton == null) return;

            if (!review.ThumbIsRed || review.ThumbStringToCompare == null)
            {
                
                if (!review.User.HasDisliked)
                {
                    review.TotalDislikes++;
                    review.User.HasDisliked = true;
                }
                
                if (review.User.HasLiked)
                {
                    review.TotalLikes--;
                    review.User.HasLiked = false;
                }
                
                review.DislikeButton.Source = review.DislikeThumbRedImgSrc;
                review.LikeButton.Source = review.LikeThumbImgSrc;
                review.ThumbIsRed = true;
                review.ThumbIsGreen = false;

                review.ThumbStringToCompare = review.DislikeThumbRedString;
            }
            else
            {
                review.User.HasDisliked = false;
                review.TotalDislikes--;
                review.DislikeButton.Source = review.DislikeThumbImgSrc;
                review.ThumbIsRed = false;

                review.ThumbStringToCompare = review.DislikeThumbString;
            }
        }

        private void CommentButton_Clicked(object sender, EventArgs e)
        {
            var commentButton = sender as ImageButton;
            var user = commentButton.BindingContext as ReviewDto;
            
            DetailsPageViewModel detailsPageViewModel = new DetailsPageViewModel(DependencyService.Get<INavService>(), user);
            detailsPageViewModel.UserToComment = user.User.FirstName + " " + user.User.LastName;

            if (!commentFrame.IsVisible)
            {
                commentFrame.IsVisible = true;
            }
            else
            {
                commentFrame.IsVisible = false;
            }
           
           

        }

        private void CloseCommentButton_Clicked(object sender, EventArgs e)
        {
            commentFrame.IsVisible = false;
        }
    }
}