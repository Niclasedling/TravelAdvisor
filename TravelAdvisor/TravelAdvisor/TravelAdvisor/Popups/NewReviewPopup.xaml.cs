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
                Dismiss(review);
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Dismiss("");
        }




    }
}