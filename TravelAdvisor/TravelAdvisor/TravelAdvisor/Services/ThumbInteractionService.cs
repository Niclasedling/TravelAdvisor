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
    public class ThumbInteractionService : IThumbInteractionService
    {
        private readonly ApiClient<ThumbInteractionDto> _thumbInteractionlient;

        public ThumbInteractionService(HttpClient httpClient)
        {
            _thumbInteractionlient = new ApiClient<ThumbInteractionDto>(httpClient, "ThumbInteraction");
        }

        public async Task<Guid> Create(ThumbInteractionCreateDto newThumbInteraction)
        {
            try
            {
                return await _thumbInteractionlient.PostAsync(newThumbInteraction);
            }
            catch (Exception mess)
            {
                throw new Exception(mess.Message);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                return await _thumbInteractionlient.DeleteAsync(id);
            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public Task<ThumbInteractionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ThumbInteractionDto>> GetById(Guid id)
        {
            var likes = await _thumbInteractionlient.GetListAsync(id);
            return likes;
        }

        public async Task<ThumbInteractionDto> GetByUserId(Guid userId)
        {
            try
            {
                return await _thumbInteractionlient.GetByUserIdAsync(userId);
            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public async Task<List<ThumbInteractionDto>> GetList()
        {
            try
            {
                return await _thumbInteractionlient.GetListAsync("GetAll");

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public async Task<bool> Update(ThumbInteractionUpdateDto thumbInteractionUpdateDto)
        {
            try
            {
                return await _thumbInteractionlient.PutAsync(thumbInteractionUpdateDto);
            }
            catch (Exception mess)
            {
                throw new Exception(mess.Message);
            }
        }
    }
}
