using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelAdvisor.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<PropertyType> PropertyTypeList => GetPropertyTypes();
        public List<Property> PropertyList => GetProperties();

        private List<PropertyType> GetPropertyTypes()
        {
            return new List<PropertyType>
            {
                new PropertyType { TypeName = "All"},
                new PropertyType { TypeName = "1 Bed"},
                new PropertyType { TypeName = "2 Beds"},
                new PropertyType { TypeName = "3 Beds"},
                new PropertyType { TypeName = "4 Beds"},
                new PropertyType { TypeName = "Under 1000"},
                new PropertyType { TypeName = "1000 or more"},
                new PropertyType { TypeName = "Popular"},
            };
        }

        private List<Property> GetProperties()
        {
            return new List<Property>
            {
                new Property
                {
                    Image = "apt1.jpg",
                    Adress = "2162 Patricia Ave, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Bed = "1 Bed",
                    Bath = "1 Bath",
                    Space = "1600 sqft",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                },
                new Property
                {
                    Image = "apt2.jpg",
                    Adress = "2112 Cushions Dr, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Bed = "1 Bed",
                    Bath = "2 Baths",
                    Space = "1600 sqft",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                },
                new Property
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Bed = "1 Bed",
                    Bath = "3 Baths",
                    Space = "1600 sqft",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                },
                 new Property
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Bed = "1 Bed",
                    Bath = "3 Baths",
                    Space = "1600 sqft",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                },
                  new Property
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Bed = "1 Bed",
                    Bath = "3 Baths",
                    Space = "1600 sqft",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                },
                   new Property
                {
                    Image = "apt3.jpg",
                    Adress = "2167 Anthony Way, LA",
                    Location = "California",
                    Price = "$1500/month",
                    Bed = "1 Bed",
                    Bath = "3 Baths",
                    Space = "1600 sqft",
                    Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia," +
                               "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,"
                }
            };
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Property;
            await this.Navigation.PushAsync(new DetailsPage(property));
        }

        private void SelectType(object sender, EventArgs e)
        {
            var view = sender as View;
            var parent = view.Parent as StackLayout;

            foreach (var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");
        }

        private void ChangeTextColor(View child, string hexColor)
        {
            var txtCtrl = child.FindByName<Label>("PropertyTypeName");
            if (txtCtrl != null)
            {
                txtCtrl.TextColor = Color.FromHex(hexColor);
            }
        }
    }

    public class PropertyType
    {
        public string TypeName { get; set; }

    }

    public class Property
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string PropertyName { get; set; }
        public string Image { get; set; }
        public string Adress { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Space { get; set; }
        public string Details { get; set; }

    }
}

