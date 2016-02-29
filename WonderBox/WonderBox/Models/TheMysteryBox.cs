using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderBox.Models
{
    public class TheMysteryBox
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<Item> Gifts { get; set; }
    }
}