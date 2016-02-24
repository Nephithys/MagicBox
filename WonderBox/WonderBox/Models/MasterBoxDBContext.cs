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

        public DbSet<MasterBox> boxes { get; set; }
    }
}
