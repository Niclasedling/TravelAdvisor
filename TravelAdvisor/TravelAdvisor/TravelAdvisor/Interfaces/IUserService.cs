using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.Services
{   
    
    public interface IUserService
    { 
        
        Task<UserDto> GetUser(Guid id);

        Task<bool> DeleteUser(Guid id);

        Task<Guid> CreateUser(UserCreateDto user);

        Task<bool> UpdateUser(UserUpdateDto user);

        Task<List<UserDto>> GetAllUsers();

        Task<Guid> Login(UserLoginDto userLogin);
        

    }
}
