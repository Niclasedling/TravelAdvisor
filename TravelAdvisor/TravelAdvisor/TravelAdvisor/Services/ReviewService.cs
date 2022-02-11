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
    public class ReviewService : IReviewService
    {
        private readonly ApiClient<ReviewDto> _reviewClient;

        public ReviewService(HttpClient httpClient)
        {
            _reviewClient = new ApiClient<ReviewDto>(httpClient, "Review");
        }

        public async Task<Guid> Create(ReviewCreateDto newReview)
        {
            try
            {
                return await _reviewClient.PostAsync(newReview);

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
                return await _reviewClient.DeleteAsync(id);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }

        public Task<ReviewDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReviewDto>> GetListById(Guid id)
        {
            try
            {
                return await _reviewClient.GetListAsyncById(id);

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message);
            }
        }
        public async Task<List<ReviewDto>> GetAllReviews()
        {
            try
            {
                return await _reviewClient.GetListAsync("GetAll");

            }
            catch (Exception mess)
            {

                throw new Exception(mess.Message); 
            }
        }

        public Task<bool> Update(ReviewUpdateDto updateReview)
        {
            throw new NotImplementedException();
        }
    }
}
