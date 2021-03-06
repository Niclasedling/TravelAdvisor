using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using TravelAdvisor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using TravelAdvisor.Popups;
using Xamarin.CommunityToolkit.Extensions;
using TravelAdvisor.Interfaces;

namespace TravelAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        UserPageViewModel ViewModel => BindingContext as UserPageViewModel;
        
        Geocoder _geocoder;
        public readonly IAttractionService _attractionService;
        public UserPage()
        {
            InitializeComponent();
            _geocoder = new Geocoder();
            _attractionService = DependencyService.Get<IAttractionService>();
            BindingContext = new UserPageViewModel(DependencyService.Get<INavService>());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(App.globalCurrentCity == "Stockholm")
            {
                _map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(59.3194903, 18.075060000000007), Distance.FromMeters(15000)));
            }
            
            await SetPins();
            // Initialize ViewModel
            ViewModel?.Init();
        }
        


        async void OnMarkerClickedAsync(object sender, PinClickedEventArgs e)
        {
            //e.HideInfoWindow = true;
            var pin = sender as Pin;
            await DisplayAlert(
                $"{pin.Label}", 
                $"Address: {pin.Address}" 
                ,"Ok");
        }

        public async Task SetPins()
        {
            var allAttractions = await _attractionService.GetAllAttractions();


            foreach (var item in allAttractions)
            {

                Position position = new Position(item.Latitude, item.Longitude);
                
                Pin newPin = new Pin
                {
                    Position = position,
                    Label = item.Name,
                    Address = item.Address,
                    Type = PinType.Place
                };
                _map.Pins.Add(newPin);
                newPin.MarkerClicked += OnMarkerClickedAsync;
            }
        }

        private async void map_MapClicked(object sender, MapClickedEventArgs e)
        {
            Position position = e.Position;
            
            var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);
            var address = addresses.FirstOrDefault();

            var result = await Navigation.ShowPopupAsync(new PointOfInterestPopup(address, position.Longitude, position.Latitude, position));
            if(result as string != "")
            {
                Pin newPin = new Pin
                {
                    Position = position,
                    Label = ((AttractionCreateDto)result).Name,
                    Address = address,
                    Type = PinType.Place
                };
                _map.Pins.Add(newPin);

                newPin.MarkerClicked += OnMarkerClickedAsync;
                await DisplayAlert("Success", "You created an attraction!", "Ok");
            }
            
           
        }

       

        private async void searchDestination_SearchButtonPressed(object sender, EventArgs e)
        {
            if (_BackButtonReviews.IsVisible)
            {
                _BackButtonReviews.IsVisible = false;
                _myReviewsButton.IsVisible = true;
                _map.IsVisible = true;
                _theReviewlist.IsVisible = false;
                _rowtwo.Height = 190;
                _cityNameLable.IsVisible = true;
                _listwithForecast.IsVisible = true;
            }
            var searchbar = sender as SearchBar;
            var userViewModel = searchbar.BindingContext as UserPageViewModel;
            userViewModel.fetchedForecast = searchDestination.Text;
            //listofOldReviews.IsEnabled = false;
            userViewModel.Forecast = await userViewModel.GetForecast();
            userViewModel.AttractionList = await userViewModel.GetAttractionsByCity(userViewModel.fetchedForecast);
            userViewModel.cityName = userViewModel.Forecast.City;
            App.globalCurrentCity = userViewModel.cityName;
            _map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(userViewModel.Forecast.Items[0].Latitude, userViewModel.Forecast.Items[0].Longitude), Distance.FromMeters(15000)));
            
        }

        private void LikeThumb_Clicked(object sender, EventArgs e)
        {
            var likeButton = sender as ImageButton;
            var review = likeButton.BindingContext as ReviewDto;

            review.LikeButton = likeButton;
            if (review.LikeButton == null) return;

            if (!review.ThumbIsGreen || review.ThumbStringToCompare == null)
            {

                if (!review.User.HasLiked)
                {
                    review.Likes++;
                    review.User.HasLiked = true;
                }

                if (review.User.HasDisliked)
                {
                    review.Dislikes--;
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
                review.Likes--;
                review.LikeButton.Source = review.LikeThumbImgSrc;
                review.ThumbIsGreen = false;
                //review.ThumbStringToCompare = review.LikeThumbString;


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
                    review.Dislikes++;
                    review.User.HasDisliked = true;
                }

                if (review.User.HasLiked)
                {
                    review.Likes--;
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
                review.Dislikes--;
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
                _theReviewlist.IsVisible = false;
                _rowtwo.Height = 307;

            }
            else
            {
                commentFrame.IsVisible = false;
                
            }
        }

        private void CloseCommentButton_Clicked(object sender, EventArgs e)
        {
            commentFrame.IsVisible = false;
            _theReviewlist.IsVisible = true;
            _rowtwo.Height = 800;
        }

        private void Comment_Completed(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            var review = App.globalCurrentReview;

            UserCommentDto userComment = new UserCommentDto();
            userComment.Comment = entry.Text;
            review.User.UserComments.Add(userComment);
            userComment.UserName = App.globalCurrentUser.UserName;

            commentListView.ItemsSource = null;
            commentListView.ItemsSource = review.User.UserComments;
            review.TotalComments = review.User.UserComments.Count;
            entry.Text = "";
        }

        private void myReview_Button_Clicked(object sender, EventArgs e)
        {
            _listwithForecast.IsVisible = false;
            _map.IsVisible = false;
            _theReviewlist.IsVisible = true;
            _myReviewsButton.IsVisible = false;
            _BackButtonReviews.IsVisible = true;
            _cityNameLable.IsVisible = false;
            _rowtwo.Height = 800;
            _BackButtonFavorites.IsVisible = false;
            _favoritesButton.IsVisible = true;
        }

        private void BackButtonReviews(object sender, EventArgs e)
        {
            _listwithForecast.IsVisible = true;
            _map.IsVisible = true;
            _theReviewlist.IsVisible = false;
            _myReviewsButton.IsVisible = true;
            _BackButtonReviews.IsVisible = false;
            _cityNameLable.IsVisible = true;
            _rowtwo.Height = 307;
        }

        private void BackButtonFavorites(object sender, EventArgs e)
        {
            _favoritesButton.IsVisible = true;
            _BackButtonFavorites.IsVisible = false;
            _map.IsVisible = true;
            _listwithForecast.IsVisible = true;
            _cityNameLable.IsVisible = true;
            _rowtwo.Height = 307;



        }

        private void _favoritesButton_Clicked(object sender, EventArgs e)
        {
            _favoritesButton.IsVisible = false;
            _BackButtonFavorites.IsVisible = true;
            _map.IsVisible = false;
            _listwithForecast.IsVisible = false;
            _cityNameLable.IsVisible = false;
            _theReviewlist.IsVisible = false;
            _BackButtonReviews.IsVisible = false;
            _myReviewsButton.IsVisible = true;
        }

        private void HeartButton_Clicked(object sender, EventArgs e)
        {
            var heartButton = sender as ImageButton;
            var attraction = heartButton.BindingContext as AttractionDto;

            if (!attraction.RedHeart || attraction.HeartstringToCompare == null)
            {
                heartButton.Source = attraction.RedHeartImage;
                attraction.HeartstringToCompare = attraction.RedHeartstringImage;
                attraction.RedHeart = true;
                attraction.Heart = false;
            }
            else
            {
                heartButton.Source = attraction.HeartImage;
                attraction.RedHeart = false;
                attraction.Heart = true;
            }
           
            
        }
    }
}