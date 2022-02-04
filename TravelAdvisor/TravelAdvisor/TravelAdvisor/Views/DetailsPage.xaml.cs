using System;
using System.Collections.Generic;
using System.Linq;
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
        DetailsPageViewModel ViewModel => BindingContext as DetailsPageViewModel;
        public DetailsPage()
        {
            
            InitializeComponent();
            
            BindingContext = new DetailsPageViewModel(DependencyService.Get<INavService>(), App.globalAttraction);
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
            var attraction = likeButton.BindingContext as AttractionDto;

            attraction.LikeButton = likeButton;
            if (attraction.LikeButton == null) return;

            if(!attraction.ThumbIsGreen || attraction.ThumbStringToCompare == null)
            {
                attraction.LikeButton.Source = attraction.LikeThumbGreenImgSrc;
                attraction.DislikeButton.Source = attraction.DislikeThumbImgSrc;
                attraction.ThumbIsGreen = true;
                attraction.ThumbIsRed = false;

                attraction.ThumbStringToCompare = attraction.LikeThumbGreenString;
            }
            else
            {

                attraction.LikeButton.Source = attraction.LikeThumbImgSrc;
                attraction.ThumbIsGreen = false;
                attraction.ThumbStringToCompare = attraction.LikeThumbString;
                
                
            }
        }

        private void DislikeThumb_Clicked(object sender, EventArgs e)
        {
            var dislikeButton = sender as ImageButton;
            var attraction = dislikeButton.BindingContext as AttractionDto;

            attraction.DislikeButton = dislikeButton;

            if (attraction.DislikeButton == null) return;

            if (!attraction.ThumbIsRed || attraction.ThumbStringToCompare == null)
            {
                attraction.DislikeButton.Source = attraction.DislikeThumbRedImgSrc;
                attraction.LikeButton.Source = attraction.LikeThumbImgSrc;
                attraction.ThumbIsRed = true;
                attraction.ThumbIsGreen = false;

                attraction.ThumbStringToCompare = attraction.DislikeThumbRedString;
            }
            else
            {
                attraction.DislikeButton.Source = attraction.DislikeThumbImgSrc;
                attraction.ThumbIsRed = false;

                attraction.ThumbStringToCompare = attraction.DislikeThumbString;
            }
        }
    }
}