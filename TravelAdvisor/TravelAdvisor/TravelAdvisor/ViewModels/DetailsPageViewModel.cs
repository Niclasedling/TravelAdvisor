using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {   
        
        private readonly IReviewService _reviewService;

        DetailsPageViewModel _detailsPageView { get { return new DetailsPageViewModel(DependencyService.Get<INavService>());} }
        
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
        
        public Command GoBack => new Command(async () => await NavigationService.GoBack());

        public DetailsPageViewModel(INavService naviService) : base(naviService)
        {
            _reviewService = DependencyService.Get<IReviewService>();
        }

        public override async void Init()
        {
            App.globalDetailsPageViewModel = _detailsPageView;
            App.globalUserToComment = new UserDto();
            App.globalUserToComment.FirstName = "";
            App.globalUserToComment.LastName = "";
            App.globalCurrentAttraction.Reviews = await GetReviews();
        }

        public List<ReviewDto> reviewList { get; set; }
        public List<ReviewDto> ReviewList { get { return reviewList; } set { reviewList = value; OnPropertyChanged("ReviewList"); } }

        private async Task<List<ReviewDto>> GetReviews()
        {

            var reviews = await _reviewService.GetListById(App.globalCurrentAttraction.Id);

            if (reviews != null)
            {
                return reviews;
            }

            return null;
        }
    }
}
