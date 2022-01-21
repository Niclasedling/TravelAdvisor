using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Interfaces
{
    public interface IUserService
    {

        Task<UserDto> GetById(Guid id);

        Task<UserDto> GetAll();

        Task<UserDto> GetList();

        Task<bool> Delete(Guid id);

        Task<UserCreateDto> Create(UserCreateDto newUser);

        Task<UserUpdateDto> Update();







    }
}
