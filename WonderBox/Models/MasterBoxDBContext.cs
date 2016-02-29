using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WonderBox.Models
{

    public class MasterBoxDBContext : DbContext
    {
        public MasterBoxDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<MasterBox> Boxes { get; set; }
        public DbSet<People> People { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<Subscription> Subcriptions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Survey> Surveys { get; set; }
    }
}
