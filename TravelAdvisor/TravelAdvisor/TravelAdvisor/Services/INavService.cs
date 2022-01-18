using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using TravelAdvisor.ViewModels;
using System.ComponentModel;

namespace TravelAdvisor.Services
{
    public interface INavService
    {
        bool CanGoBack { get; }

        Task GoBack();

        Task NavigateTo<TVM>() where TVM : BaseViewModel;

        Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : BaseViewModel;

        Task NavigateToView(Type viewModelType);

        void RemoveLastView();

        void ClearBackStack();

        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
