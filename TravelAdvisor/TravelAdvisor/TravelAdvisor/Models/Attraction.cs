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
