using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetById(Guid id);

        Task<List<CommentDto>> GetAll();

        Task<List<CommentDto>> GetList();

        Task<bool> Delete(Guid id);

        Task<Guid> Create(CommentCreateDto commentCreateDto);

        Task<bool> Update(CommentUpdateDto commentUpdateDto);
    }
}
