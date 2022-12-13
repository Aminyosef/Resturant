using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DataBanse
{
    public class DBConnection : DbContext
    {
      public DBConnection():base("name=conn") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }      
        public DbSet<Item> Items { get; set; }
        public DbSet<Option> Options { get; set; }

    }
}
