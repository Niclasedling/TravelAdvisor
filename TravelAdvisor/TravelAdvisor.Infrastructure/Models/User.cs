using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Models
{
    public abstract class UserBase
    {
      
        public Guid Id { get; set; }

    
        public string FirstName { get; set; }

      
        public string LastName { get; set; }

      
        public string Email { get; set; }

       
        public string Password { get; set; }

       
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modify { get; set; }

    }

    public class UserDto : UserBase
    {






    }

    public class UserUpdateDto : UserBase
    {









    }

    public class UserDeleteDto
    {

        public Guid Id { get; set; }



    }

    public class UserBasicDto
    {







    }

    public class UserCreateDto
    {
        public object Password { get; internal set; }
    }

}
