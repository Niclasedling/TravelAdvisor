using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.ApiClient;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;
using Xamarin.Forms;

namespace TravelAdvisor.Services
{
    public class ForecastService : IForecastService
    {
        private readonly ApiClient<Weather> _forecastServiceClient;
        private readonly INavService _navService;


        public ForecastService(HttpClient httpClient)
        {
            _forecastServiceClient = new ApiClient<Weather>(httpClient, "Forecast");
            _navService = DependencyService.Get<INavService>();

        }

        public async Task<List<Weather>> GetForcast(string cityName)
        {
            string path = $"GetAll?cityName={cityName}";

            var item = await _forecastServiceClient.GetListAsync( path);

            
            return item;
        }


    }
}
