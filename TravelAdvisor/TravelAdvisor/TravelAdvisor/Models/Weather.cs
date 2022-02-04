using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAdvisor.Models
{
    public class Weather
    {

        public double Temperature { get; set; }
        public string DateofForecast { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Icon { get; set; }
    }
}
