using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Property property)
        {
            InitializeComponent();
            this.Property = property;
            this.BindingContext = this;
        }

        public Property Property { get; set; }
        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}