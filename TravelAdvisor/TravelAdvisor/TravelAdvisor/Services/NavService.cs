using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.ViewModels;
using TravelAdvisor.Views;
using Xamarin.Forms;

namespace TravelAdvisor.Services
{
    public class NavService : INavService
    {
        readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        public NavService()
        {
           
            _map.Add(typeof(LoginPageViewModel), typeof(LoginPage));
            _map.Add(typeof(SignUpPageViewModel), typeof(SignUpPage));
            //mappa alla här!

        }

        public event PropertyChangedEventHandler CanGoBackChanged;

        public INavigation Navigation { get; set; }

        public bool CanGoBack => Navigation.NavigationStack?.Any() == true;

        public async Task GoBack()
        {
            if (CanGoBack)
            {
                await Navigation.PopAsync(true);
                OnCanGoBackChanged();
            }
        }

        public async Task NavigateTo<TVM>() where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));

            if (Navigation.NavigationStack.Last().BindingContext is BaseViewModel)
            {
                ((BaseViewModel)Navigation.NavigationStack.Last().BindingContext).Init();
            }
        }

        public async Task NavigateTo<TVM, TParameter>(TParameter parameter)
            where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));

            if (Navigation.NavigationStack.Last().BindingContext is BaseViewModel<TParameter>)
            {
                ((BaseViewModel<TParameter>)Navigation.NavigationStack.Last().BindingContext).Init(parameter);
            }
        }

        public void RemoveLastView()
        {
            if (Navigation.NavigationStack.Count < 2)
            {
                return;
            }

            var lastView = Navigation.NavigationStack[Navigation.NavigationStack.Count - 2];

            Navigation.RemovePage(lastView);
        }

        public void ClearBackStack()
        {
            if (Navigation.NavigationStack.Count < 2)
            {
                return;
            }

            for (var i = 0; i < Navigation.NavigationStack.Count - 1; i++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[i]);
            }
        }

        public async Task NavigateToView(Type viewModelType)
        {
            if (!_map.TryGetValue(viewModelType, out Type viewType))
            {
                throw new ArgumentException("No view found in view mapping for " + viewModelType.FullName + ".");
            }

            // Use reflection to get the View's constructor and create an instance of the View
            var constructor = viewType.GetTypeInfo()
                                      .DeclaredConstructors
                                      .FirstOrDefault(dc => !dc.GetParameters().Any());
            var view = constructor.Invoke(null) as Page;
            
            await Navigation.PushAsync(view, true);
        }

        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _map.Add(viewModel, view);
        }

        void OnCanGoBackChanged() => CanGoBackChanged?.Invoke(this, new PropertyChangedEventArgs("CanGoBack"));

        public void SetNavigation(INavigation navigation)
        {
            Navigation = navigation;
        }
    }
}

