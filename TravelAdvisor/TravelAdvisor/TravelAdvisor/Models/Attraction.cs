using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using TravelAdvisor.ViewModels;
using Xamarin.Forms.Maps;

namespace TravelAdvisor.Models
{
    public abstract class AttractionBase
    {     
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set ; }

        public string HeartstringToCompare { get; set; }
        public string Address { get; set; }
        public ImageSource HeartImage { get { return "noun-favourite-1077408.png"; } }
        public string HeartstringImage { get { return "noun-favourite-1077408.png"; } }
        public bool _heart = false;
        public bool Heart { get { return _heart; } set { _heart = value; } }
        public ImageSource RedHeartImage { get { return "noun-Redfavourite-1077408.png"; } }
        public string RedHeartstringImage { get { return "noun-Redfavourite-1077408.png"; } }
        public bool _redheart = false;
        public bool RedHart { get { return _redheart; } set { _redheart = value; } }

        public string Location { get; set; }

        public string Price { get; set; } // Ska vara int

        public string Details { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public List<ReviewDto> Reviews { get; set; }

        public bool IsFavorited { get; set; }


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

        public string Address { get; set; }

        public int? Price { get; set; }

        public string Details { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string City { get; set; }

        public Position Position { get; set; }

    }
}
