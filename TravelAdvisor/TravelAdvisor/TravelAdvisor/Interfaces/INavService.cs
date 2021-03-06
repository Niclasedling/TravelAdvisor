using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using TravelAdvisor.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using TravelAdvisor.Models;

namespace TravelAdvisor.Services
{
    public interface INavService
    {
        bool CanGoBack { get; }

        Task GoBack();

        Task NavigateTo<TVM>() where TVM : BaseViewModel;
        Task NavigateTo<TVM>(AttractionDto attraction) where TVM : BaseViewModel;
        Task NavigateTo<TVM>(UserBase user) where TVM : BaseViewModel;

        Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : BaseViewModel;

        Task NavigateToView(Type viewModelType);

        void RemoveLastView();

        void ClearBackStack();

        void SetNavigation(INavigation navigation);

        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
