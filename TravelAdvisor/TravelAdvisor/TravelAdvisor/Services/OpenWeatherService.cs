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
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly ApiClient<Forecast> _forecastServiceClient;
        private readonly INavService _navService;


        public OpenWeatherService(HttpClient httpClient)
        {
            _forecastServiceClient = new ApiClient<Forecast>(httpClient, "Forecast");
            _navService = DependencyService.Get<INavService>();

        }

        public async Task<Forecast> GetForcast(string cityName)
        {
            try
            {
                string path = $"GetAll?cityName={cityName}";

                var item = await _forecastServiceClient.GetListAsync(path, "data");

                return item;
            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message); 
            }
            
        }


    }
}
