using System;
using System.Collections.Generic;
using System.Text;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Services;
using Xamarin.Forms;
using TravelAdvisor.Models;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;

namespace TravelAdvisor.ViewModels
{
    public class CreateAttractionViewModel : BaseViewModel
    {
        // Services
        private readonly IUserService _userService;
        private readonly INavService _navService;
        private readonly IReviewService _reviewService;
        private IAttractionService _attractionService;

        public CreateAttractionViewModel _createAttractionViewModel;

        // Props
        private AttractionCreateDto _Attraction { get; set; }
        public AttractionCreateDto Attraction
        {
            get { return _Attraction; }
            set { _Attraction = value; OnPropertyChanged("Attraction"); }
        }
        private Position _Position { get; set; }
        public Position Position
        {
            get { return _Position; }
            set { _Position = value; OnPropertyChanged("Position"); }
        }


        // Commands
        public Command GoBack => new Command(async () => await NavigationService.GoBack());
        public Command MainPage => new Command(async () => await NavigationService.NavigateTo<MainPageViewModel>());
        public Command CreateAttraction => new Command(async () => await CreateNewAttraction());

        public CreateAttractionViewModel(INavService naviService) : base(naviService)
        {
            _userService = DependencyService.Get<IUserService>();
            _navService = DependencyService.Get<INavService>();
            _reviewService = DependencyService.Get<IReviewService>();
            _attractionService = DependencyService.Get<IAttractionService>();
        }

        public override void Init()
        {
            Attraction = new AttractionCreateDto();
        }

        public async Task<bool> CreateNewAttraction()
        {
            var attractionId = await _attractionService.CreateAttraction(Attraction);
            
            if (attractionId != null)
            {
                return true;
            }

            return false;
        }
    }
}
