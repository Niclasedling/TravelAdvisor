using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TravelAdvisor.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("Aohsy1MqXcu_h41UHuKJ-2-IeWXvcP17tBZ4d5bSwouX5FarhgDbYv741ZxqwiWh");
            Windows.Services.Maps.MapService.ServiceToken = "Aohsy1MqXcu_h41UHuKJ-2-IeWXvcP17tBZ4d5bSwouX5FarhgDbYv741ZxqwiWh";
            LoadApplication(new TravelAdvisor.App());
        }
    }
}
