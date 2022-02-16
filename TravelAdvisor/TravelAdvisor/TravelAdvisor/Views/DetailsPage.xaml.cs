using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using TravelAdvisor.Popups;
using TravelAdvisor.Services;
using TravelAdvisor.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {    
        DetailsPageViewModel ViewModel => BindingContext as DetailsPageViewModel;
        public DetailsPage()
        {
            InitializeComponent();         
            BindingContext = new DetailsPageViewModel(DependencyService.Get<INavService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();        
            ViewModel?.Init();          
        }

        private async void LikeThumb_Clicked(object sender, EventArgs e)
        {
            var likeButton = sender as ImageButton;    
            //var review = likeButton.BindingContext as ReviewDto;
            
            if (ViewModel.CurrentReview.ThumbInteraction != null)
            {
                await ViewModel.UpdateThumbInteraction(new ThumbInteractionUpdateDto
                {
                    Id = ViewModel.CurrentReview.ThumbInteraction.Id,
                    ReviewId = ViewModel.CurrentReview.Id,
                    UserId = App.globalCurrentUser.Id,
                    HasLiked = true,
                });
                ViewModel.CurrentReview.LikeThumbImgSrc = ViewModel.CurrentReview.LikeThumbDefault;
                ViewModel.CurrentReview.DislikeThumbImgSrc = ViewModel.CurrentReview.DislikeThumbDefault;
            }
            else
            {
                await ViewModel.CreateThumbInteraction(new ThumbInteractionCreateDto
                {
                    ReviewId = ViewModel.CurrentReview.ThumbInteraction.Id,
                    UserId = App.globalCurrentUser.Id,
                    HasLiked = true,
                });
                ViewModel.CurrentReview.LikeThumbImgSrc = ViewModel.CurrentReview.LikeThumbGreenImgSrc;
                ViewModel.CurrentReview.DislikeThumbImgSrc = ViewModel.CurrentReview.DislikeThumbDefault;
            }
        }

        private async void DislikeThumb_Clicked(object sender, EventArgs e)
        {
            var likeButton = sender as ImageButton;
            //var review = likeButton.BindingContext as ReviewDto;

            if (ViewModel.CurrentReview.ThumbInteraction != null)
            {
                await ViewModel.UpdateThumbInteraction(new ThumbInteractionUpdateDto
                {
                    Id = ViewModel.CurrentReview.ThumbInteraction.Id,
                    ReviewId = ViewModel.CurrentReview.Id,
                    UserId = App.globalCurrentUser.Id,
                    HasLiked = false,
                });
            }
            else
            {
                await ViewModel.CreateThumbInteraction(new ThumbInteractionCreateDto
                {
                    ReviewId = ViewModel.CurrentReview.ThumbInteraction.Id,
                    UserId = App.globalCurrentUser.Id,
                    HasLiked = false,
                });
                ViewModel.CurrentReview.LikeThumbImgSrc = ViewModel.CurrentReview.LikeThumbDefault;
                ViewModel.CurrentReview.DislikeThumbImgSrc = ViewModel.CurrentReview.DislikeThumbRedImgSrc;
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
            
            var result = await Navigation.ShowPopupAsync(new NewReviewPopup());
            if (result as string != "")
            {
                await DisplayAlert("Success", "You created an review!", "Ok");
            }
            
        }

        
    }
}