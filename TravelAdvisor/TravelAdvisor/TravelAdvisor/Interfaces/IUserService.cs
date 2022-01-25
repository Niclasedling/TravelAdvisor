using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Models;

namespace TravelAdvisor.Services
{   
    
    public interface IUserService
    { 
        
        //Forsätt här

          Task<UserDto> GetUser(Guid id);


          Task<bool> DeleteUser(Guid id);



          Task<Guid> CreateUser(UserDto user);



           Task<bool> UpdateUser(UserDto user);



           Task<List<UserDto>> GetAllUsers();
        

    }
}
