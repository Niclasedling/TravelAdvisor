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

        public Task<Guid> Create(ThumbInteractionCreateDto thumbInteractionCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ThumbInteractionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ThumbInteractionDto>> GetById(Guid id)
        {
            var likes = await  _thumbInteractionlient.GetListAsync(id);
           
            return likes;
        }

        public Task<ThumbInteractionDto> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ThumbInteractionDto>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ThumbInteractionUpdateDto thumbInteractionUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
