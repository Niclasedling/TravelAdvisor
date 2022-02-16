using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.Interfaces
{
    public interface IThumbInteractionService
    {
        Task<Guid> Create(ThumbInteractionCreateDto thumbInteractionCreateDto);

        Task<List<ThumbInteractionDto>> GetById(Guid id);

        Task<ThumbInteractionDto> GetAll();

        Task<List<ThumbInteractionDto>> GetList();

        Task<List<ThumbInteractionDto>> GetByUserId(Guid userId);

        Task<bool> Update(ThumbInteractionUpdateDto thumbInteractionUpdateDto);

        Task<bool> Delete(Guid id);
    }
}
