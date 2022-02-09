using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TravelAdvisor.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        public async Task<GeoLocation> GetGeoLocationAsync()
        {
            var geo = await Geolocation.GetLocationAsync();
            return new GeoLocation { Latitude = geo.Latitude, Longitude = geo.Longitude };
        }
        public async Task<GeoLocation> PinLocation()
        {
            return null;
        }
    }
}
