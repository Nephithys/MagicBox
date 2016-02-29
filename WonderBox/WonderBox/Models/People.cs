using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WonderBox.Models
{
    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public int TotalBoxesOrdered { get; set; }
    }
}