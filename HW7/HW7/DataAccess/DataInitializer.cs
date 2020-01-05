using HW7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW7.DataAccess
{
    public class DataInitializer:DropCreateDatabaseAlways<DataAppContext>
    {
        protected override void Seed(DataAppContext context)
        {
            Role admin = new Role { Name = "admin" };
            Role user = new Role { Name = "user" };

            context.Roles.Add(admin);
            context.Roles.Add(user);

            context.Users.Add(new User
            {
                Login = "admin",
                Password = "123456",
                Role = admin
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}