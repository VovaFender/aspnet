using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace MvcApplication1.Models
{
    public class UserRepository : IUserRepository
    {
        [Inject]
        public aspnetEntities DBEntities { get; set; }
        
        public IQueryable<user> Users 
        {
            get { return DBEntities.users; }            
        }

        public bool CreateUser(user instance)
        {
            DBEntities.users.Add(instance);
            DBEntities.SaveChanges();
            return true;
        }

        public bool UpdateUser(user instance)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(int userID)
        {
            throw new NotImplementedException();
        }

        public user GetUser(string email)
        {
            var userByEmail = DBEntities.users.Where(u => String.Compare(u.email, email) == 0).FirstOrDefault();
            return userByEmail;
        }

        public user GetUser(int id)
        {
            var userByID = DBEntities.users.Where(u => u.id == id).FirstOrDefault();

            return userByID;
        }

        public string GetUserRole(user currUser)
        {            
            string userRole = DBEntities.userroles.Where(r => r.id == currUser.user_role).FirstOrDefault().name;

            return userRole;
        }
        public user Login(string email, string password)
        {
            var logUser = DBEntities.users.FirstOrDefault(u => string.Compare(u.email, email, true) == 0
                                                               && u.password == password);
            return logUser;
        }
        public user Login(string email)
        {
            var logUser = DBEntities.users.FirstOrDefault(u => string.Compare(u.email, email, true) == 0);

            return logUser;
        }
    }
}