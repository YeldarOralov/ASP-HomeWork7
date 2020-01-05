using HW7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW7.DataAccess
{
    public class DataAppContext : DbContext
    {
        public DataAppContext() : base("name=DataAppContext")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
