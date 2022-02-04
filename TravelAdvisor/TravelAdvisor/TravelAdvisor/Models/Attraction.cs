using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using TravelAdvisor.ViewModels;

namespace TravelAdvisor.Models
{
    public abstract class AttractionBase
    {     
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Adress { get; set; }

        public string Location { get; set; }

        public string Price { get; set; } // Ska vara int

        public string Details { get; set; }


        public string ThumbStringToCompare { get; set; }

        public ImageSource DislikeThumbImgSrc { get { return "dislike.png"; }}
        public string DislikeThumbString { get { return "dislike.png"; } }


        public ImageSource LikeThumbImgSrc { get { return "like.png"; } }
        public string LikeThumbString { get { return "like.png"; } }


        public ImageSource DislikeThumbRedImgSrc { get { return "dislikered.png"; } }
        public string DislikeThumbRedString { get { return "dislikered.png"; } }


        public ImageSource LikeThumbGreenImgSrc { get { return "likegreen.png"; } }
        public string LikeThumbGreenString { get { return "likegreen.png"; } }



        public ImageButton LikeButton = new ImageButton();

        public ImageButton DislikeButton = new ImageButton();

        public bool _thumbIsGreen = false;
        public bool ThumbIsGreen { get { return _thumbIsGreen; } set { _thumbIsGreen = value; } }
        public bool _thumbIsRed = false;
        public bool ThumbIsRed { get { return _thumbIsRed; } set { _thumbIsRed = value; } }
        
        

        

        //public List<ReviewDto> Reviews { get; set; }

    }
    
    public class AttractionDto : AttractionBase
    {
       
    }

    public class AttractionUpdateDto : AttractionBase
    {

    }

    public class AttractionDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class AttractionBasicDto
    {

    }

    public class AttractionCreateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Adress { get; set; }

        public string Location { get; set; }

        public int? Price { get; set; }

        public string Details { get; set; }

        //public List<ReviewDto> Reviews { get; set; }
    }
}
