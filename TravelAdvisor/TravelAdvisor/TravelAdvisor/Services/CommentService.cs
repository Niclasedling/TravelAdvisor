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
    public class CommentService : ICommentService
    {
        private readonly ApiClient<CommentDto> _commentClient;

        public CommentService(HttpClient httpClient)
        {
            _commentClient = new ApiClient<CommentDto>(httpClient, "Comment");
        }

        public async Task<Guid> Create(CommentCreateDto commentCreateDto)
        {
            try
            {
                return await _commentClient.PostAsync(commentCreateDto);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDto>> GetAll()
        {
            try
            {
                return await _commentClient.GetListAsync("GetAll");

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public Task<List<CommentDto>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDto>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CommentUpdateDto commentUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
