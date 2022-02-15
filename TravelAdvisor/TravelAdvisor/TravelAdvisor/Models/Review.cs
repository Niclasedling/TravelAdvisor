using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TravelAdvisor.Models
{
    //public enum Rating
    //{
    //    Unspecified,
    //    VeryBad,
    //    Bad,
    //    Average,
    //    VeryGood,
    //    Excellent,
    //}
    public class ReviewBase : INotifyPropertyChanged
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ImageSource Image { get { return "user.png"; } }
        public string Description { get; set; }
        public string ThumbStringToCompare { get; set; }

        public ImageSource DislikeThumbImgSrc { get { return "dislike.png"; } }
        public string DislikeThumbString { get { return "dislike.png"; } }


        public ImageSource LikeThumbImgSrc { get { return "like.png"; } }
        public string LikeThumbString { get { return "like.png"; } }


        public ImageSource DislikeThumbRedImgSrc { get { return "dislikered.png"; } }
        public string DislikeThumbRedString { get { return "dislikered.png"; } }


        public ImageSource LikeThumbGreenImgSrc { get { return "likegreen.png"; } }
        public string LikeThumbGreenString { get { return "likegreen.png"; } }

        public ImageSource CommentImgSrc { get { return "comment.png"; } }



        public ImageButton LikeButton = new ImageButton();

        public ImageButton DislikeButton = new ImageButton();

        public bool _thumbIsGreen = false;
        public bool ThumbIsGreen { get { return _thumbIsGreen; } set { _thumbIsGreen = value; } }
        public bool _thumbIsRed = false;

        

        public bool ThumbIsRed { get { return _thumbIsRed; } set { _thumbIsRed = value; } }

        public UserDto User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int totalLikes { get; set; }
        public int TotalLikes 
        { 
            get { return totalLikes; }
            set
            {
                totalLikes = value;
                OnPropertyChanged("TotalLikes");
            }
        }
        private int totalDislikes { get; set; } 
        public int TotalDislikes 
        { 
            get { return totalDislikes; }
            set 
            {
                totalDislikes = value;
                OnPropertyChanged("TotalDislikes");
            }
        }
        private int totalComments { get; set; }
        public int TotalComments 
        { 
            get { return totalComments; }
            set 
            {
                totalComments = value;
                OnPropertyChanged("TotalComments");
            }
        }

      

    }

    public class ReviewDto : ReviewBase
    {





    }
    public class ReviewBasicDto
    {







    }

    public class ReviewCreateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        //public Rating Rating { get; set; } = Rating.Unspecified;

        public int Rating { get; set; }

        public Guid UserId { get; set; } // Id

        public Guid AttractionId { get; set; }

        public ImageSource Image { get; set; }

    }

    public class ReviewUpdateDto
    {

    }
}
