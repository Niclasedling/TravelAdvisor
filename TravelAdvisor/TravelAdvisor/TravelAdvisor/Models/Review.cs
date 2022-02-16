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
        public AttractionDto Attraction { get; set; }

        public ThumbInteractionDto ThumbInteraction { get; set; }


        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }

        public ImageSource Image { get { return "user.png"; } }

        public string Description { get; set; }
        public string ThumbStringToCompare { get; set; }

        public string DislikeThumbString { get { return "dislike.png"; } }
        
        public ImageSource YellowStar { get { return "newstar.png"; } }
        public ImageSource WhiteStar { get { return "emptyStar.png"; } }
        public ImageSource OneStar { get; set; }
        public ImageSource TwoStars { get; set; }
        public ImageSource ThreeStars { get; set; }
        public ImageSource FourStars { get; set; }
        public ImageSource FiveStars { get; set; }

        private ImageSource likeThumbImgSrc { get; set; }
        public ImageSource LikeThumbImgSrc { get { return likeThumbImgSrc; } set { likeThumbImgSrc = value; OnPropertyChanged("LikeThumbImgSrc"); } }
        private ImageSource dislikeThumbImgSrc { get; set; }
        public ImageSource DislikeThumbImgSrc { get { return dislikeThumbImgSrc; } set { dislikeThumbImgSrc = value; OnPropertyChanged("DislikeThumbImgSrc"); } }

        public ImageSource LikeThumbDefault { get { return "like.png"; } }
        public ImageSource DislikeThumbDefault { get { return "dislike.png"; } }


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

        private List<CommentDto> commentList { get; set; } = new List<CommentDto>();
        public List<CommentDto> CommentList { get { return commentList; } set { commentList = value; OnPropertyChanged("CommentList"); } } 

        private int? likes { get; set; }
        public int? Likes 
        { 
            get { return likes; }
            set
            {
                likes = value;
                OnPropertyChanged("Likes");
            }
        }
        private int? dislikes { get; set; } 
        public int? Dislikes 
        { 
            get { return dislikes; }
            set 
            {
                dislikes = value;
                OnPropertyChanged("Dislikes");
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
        public Guid AttractionId { get; set; }
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
