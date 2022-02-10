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
        //AttractionDto attraction = new AttractionDto();
        DetailsPageViewModel ViewModel => BindingContext as DetailsPageViewModel;
        public DetailsPage()
        {
            
            InitializeComponent();
            
            BindingContext = new DetailsPageViewModel(DependencyService.Get<INavService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Initialize ViewModel
            
            ViewModel?.Init();
            
            
        }

        //private void SetThumbValues()
        //{
        //    if()
        //}

        private void LikeThumb_Clicked2(object sender, EventArgs e)
        {
            var likeButton = sender as ImageButton;
            var review = likeButton.BindingContext as ReviewDto;

            review.LikeButton = likeButton;
            if (review.LikeButton == null) return;

            if (App.globalCurrentUser.HasLikedReview.ContainsKey(review.Id))
            {
                //App.globalCurrentUser.HasLiked
                if (App.globalCurrentUser.HasLikedReview.ContainsKey(review.Id) && App.globalCurrentUser.HasLikedReview.ContainsValue(false)
                    || !App.globalCurrentUser.HasLikedReview.ContainsKey(review.Id))
                {
                    review.TotalLikes++;
                    App.globalCurrentUser.HasLikedReview.Add(review.Id, true);
                }

                if (App.globalCurrentUser.HasLikedReview.ContainsKey(review.Id) && App.globalCurrentUser.HasLikedReview.ContainsValue(true)
                    || !App.globalCurrentUser.HasLikedReview.ContainsKey(review.Id))
                {
                    review.TotalDislikes--;
                    App.globalCurrentUser.HasLikedReview.Add(review.Id, false);
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
            var review = commentButton.BindingContext as ReviewDto;

            App.globalCurrentReview = review;
            commentListView.ItemsSource = review.User.UserComments;
            //App.globalDetailsPageViewModel.UserToComment = review.User.FirstName + " " + review.User.LastName;
          

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

        private void Comment_Completed(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            var review = App.globalCurrentReview;
           
            UserCommentDto userComment = new UserCommentDto();
            userComment.Comment = entry.Text;
            review.User.UserComments.Add(userComment);

            commentListView.ItemsSource = null;
            commentListView.ItemsSource = review.User.UserComments;
            review.TotalComments = review.User.UserComments.Count;
            entry.Text = "";
        }

        private async void AddReview_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            //var review = button.BindingContext as ReviewDto;

            var reviewAnswer = await DisplayPromptAsync("New Review", "Review", "Ok", "Cancel");
            var ratingAnswer = await DisplayPromptAsync("Attraction rating", "Rating", "Ok", "Cancel");
            //ReviewDto review = new ReviewDto()
            //{
            //    User
            //}
            //App.globalCurrentAttraction.Reviews.Add()
        }
    }
}