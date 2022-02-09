using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.ApiClient;
using TravelAdvisor.Interfaces;
using TravelAdvisor.Models;

namespace TravelAdvisor.Services
{
    public class AttractionService : IAttractionService
    {
        private readonly ApiClient<AttractionDto> _attractionClient;

        public AttractionService(HttpClient httpClient)
        {
            _attractionClient = new ApiClient<AttractionDto>(httpClient, "Attraction");
        }

        public async Task<AttractionDto> GetAttraction(Guid id)
        {
            return await _attractionClient.GetAsync(id);
        }

        public async Task<List<AttractionDto>> GetAllAttractions()
        {
            return await _attractionClient.GetListAsync("GetList");
        }
        public async Task<Guid> CreateAttraction(AttractionCreateDto newAttraction)
        {
            return await _attractionClient.PostAsync(newAttraction);
        }

        public async Task<bool> DeleteAttraction(Guid id)
        {
            return await _attractionClient.DeleteAsync(id);
        }

        public async Task<bool> UpdateAttraction(AttractionUpdateDto updateAttraction)
        {
            return await _attractionClient.PutAsync(updateAttraction);
        }

        public async Task<List<AttractionDto>> GetAllAttractionsByCity(string city)
        {
            return await _attractionClient.GetListAsync("GetListByCity");
        }
    }
}
