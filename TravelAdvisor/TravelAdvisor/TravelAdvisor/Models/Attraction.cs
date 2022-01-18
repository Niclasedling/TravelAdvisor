using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAdvisor.Models
{
    public class Attraction
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string Name { get; set; }
        public string Image { get; set; }
        public string Adress { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Space { get; set; }
        public string Details { get; set; }
    }
}
