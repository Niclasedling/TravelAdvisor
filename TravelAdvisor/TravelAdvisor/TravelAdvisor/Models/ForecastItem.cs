using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace TravelAdvisor.Models
{
    public class ForecastItem
    {
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Humidity { get; set; }
        public string CityName { get; set; }
        public Position Position { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
