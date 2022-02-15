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
        private readonly ApiClient<CommentService> _commentClient;

        public CommentService(HttpClient httpClient)
        {
            _commentClient = new ApiClient<CommentService>(httpClient, "Comment");
        }

        public Task<Guid> Create(CommentCreateDto commentCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> GetAll()
        {
            throw new NotImplementedException();
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
