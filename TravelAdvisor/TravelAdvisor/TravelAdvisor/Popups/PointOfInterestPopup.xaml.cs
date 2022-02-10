using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAdvisor.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PointOfInterestPopup : Popup
    {
        public PointOfInterestPopup()
        {
            InitializeComponent();
            

        }

        private void Star_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            
        }
    }
}