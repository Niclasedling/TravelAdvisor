﻿using System;
using System.Collections.Generic;
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
        public async Task<Guid> Create(ReviewCreateDto newReview)
        {
            return await _reviewClient.PostAsync(newReview);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _reviewClient.DeleteAsync(id);
        }

        public Task<ReviewDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReviewDto>> GetList()
        {
            return await _reviewClient.GetListAsync("GetList");
        }

        public Task<bool> Update(ReviewUpdateDto updateReview)
        {
            throw new NotImplementedException();
        }
    }
}
