using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TravelAdvisor.Models
{



    public abstract class UserBase : INotifyPropertyChanged
    {

        public Guid Id { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }
        public string Fullname { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modify { get; set; }
        public string Review { get; set; }
       

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        private List<UserCommentDto> userComments = new List<UserCommentDto>();
        public List<UserCommentDto> UserComments 
        { 
            get 
            { 
                return userComments; 
            } 
            set 
            { 
                userComments = value;
                OnPropertyChanged("UserComments");
            } 
        }
        private bool hasLiked { get; set; }
        public bool HasLiked { get { return hasLiked; } set { hasLiked = value; } }
        private bool hasDisliked { get; set; }
        public bool HasDisliked { get { return hasDisliked; } set { hasDisliked = value; } }


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
    public class UserCommentDto : UserBase
    {
        private string comment { get; set; }
        public string Comment 
        { 
            get 
            { 
                return comment;
            }
            set 
            {
                comment = value;
                OnPropertyChanged("Comment");
            }
        }
    }

}


