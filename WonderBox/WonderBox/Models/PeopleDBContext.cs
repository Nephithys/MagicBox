using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WonderBox.Models
{
    public class PeopleDBContext:DbContext
    {
        public PeopleDBContext() : base("DefaultConnection")
        {

        }
        public DbSet<People> LotsOfPeople { get; set; }
    }
}