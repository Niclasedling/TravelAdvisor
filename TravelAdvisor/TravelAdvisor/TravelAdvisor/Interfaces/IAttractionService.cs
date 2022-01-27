using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.Interfaces
{
    public interface IAttractionService
    {
        Task<AttractionDto> GetAttraction(Guid id);

        //Task<AttractionDto> GetAllAttractions();

        Task<List<AttractionDto>> GetAllAttractions();

        Task<bool> DeleteAttraction(Guid id);

        Task<Guid> CreateAttraction(AttractionCreateDto newAttraction);

        Task<bool> UpdateAttraction(AttractionUpdateDto updateAttraction);
    }
}
