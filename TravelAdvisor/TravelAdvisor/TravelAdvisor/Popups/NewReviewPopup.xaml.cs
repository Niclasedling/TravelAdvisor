using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;
using TravelAdvisor.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewReviewPopup : Popup
    {
        public NewReviewPopup()
        {
            InitializeComponent();
        }

        private async void Create_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var detailsPageViewModel = button.BindingContext as DetailsPageViewModel;

            var review = new ReviewCreateDto
            {
               Id = Guid.NewGuid(),
               Title = detailsPageViewModel.TitleOfNewReview,
               Description = detailsPageViewModel.DesciptionOfNewReview,
               Rating = detailsPageViewModel.RatingOfNewReview,
               UserId = App.globalCurrentUser.Id,
               AttractionId = App.globalCurrentAttraction.Id,
               
            };

            var guid = await detailsPageViewModel._reviewService.Create(review);
            if (guid == Guid.Empty || guid == null)
            {
                throw new Exception("Guid is empty");
            }
            else
            {
                detailsPageViewModel.ReviewList = await detailsPageViewModel._reviewService.GetListById(App.globalCurrentAttraction.Id);
                SetStars(detailsPageViewModel.ReviewList);
                Dismiss(review);
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Dismiss("");
        }

        public void SetStars(List<ReviewDto> listOfReviews)
        {
            foreach (var item in listOfReviews)
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
        }


    }
}