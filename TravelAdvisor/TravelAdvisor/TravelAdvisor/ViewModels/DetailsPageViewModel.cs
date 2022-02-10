using System;
using System.Collections.Generic;
using System.Linq;
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
            ReviewList = await GetReviews();
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
