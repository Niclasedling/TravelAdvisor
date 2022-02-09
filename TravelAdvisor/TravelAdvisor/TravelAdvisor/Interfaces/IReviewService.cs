using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> GetById(Guid id);

        Task<ReviewDto> GetAll();

        Task<List<ReviewDto>> GetListById(Guid Id);

        Task<bool> Delete(Guid id);

        Task<Guid> Create(ReviewCreateDto newReview);

        Task<bool> Update(ReviewUpdateDto updateReview);
    }
}
