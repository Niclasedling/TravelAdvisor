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
            try
            {
                return await _attractionClient.GetAsync(id);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public async Task<List<AttractionDto>> GetAllAttractions()
        {
            try
            {
                return await _attractionClient.GetListAsync("GetList");

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }
        public async Task<Guid> CreateAttraction(AttractionCreateDto newAttraction)
        {
            try
            {
                return await _attractionClient.PostAsync(newAttraction);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public async Task<bool> DeleteAttraction(Guid id)
        {
            try
            {
                return await _attractionClient.DeleteAsync(id);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public async Task<bool> UpdateAttraction(AttractionUpdateDto updateAttraction)
        {

            try
            {
                return await _attractionClient.PutAsync(updateAttraction);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public async Task<List<AttractionDto>> GetAllAttractionsByCity(string city)
        {
            try
            {
                return await _attractionClient.GetListAsyncByCity(city);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message); 
            }
        }
    }
}
