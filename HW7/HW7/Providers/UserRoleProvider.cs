using HW7.DataAccess;
using HW7.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HW7.Providers
{
    public class UserRoleProvider : RoleProvider
    {
        private readonly DataAppContext db = new DataAppContext();
        public override string[] GetRolesForUser(string login)
        {
            string[] roles = new string[] { };
            // Получаем пользователя
            var user = db.Users.Include(x=>x.Role).FirstOrDefault(u => u.Login == login);
            if (user != null && user.Role != null)
            {
                // получаем роль
                roles = new string[] { user.Role.Name };
            }
            return roles;

        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string login, string roleName)
        {
            // Получаем пользователя
            User user = db.Users.Include(x => x.Role).FirstOrDefault(u => u.Login == login);

            if (user != null && user.Role != null && user.Role.Name == roleName)
                return true;
            else
                return false;

        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}