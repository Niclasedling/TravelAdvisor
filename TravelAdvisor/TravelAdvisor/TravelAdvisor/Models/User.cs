using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAdvisor.Models
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserLoginDto
    {

        public string Email { get; set; }

        public string Password { get; set; }

    }

}


