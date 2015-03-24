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
        public BookShopEntities DBEntities { get; set; }
        
        public IQueryable<User> Users 
        {
            get { return DBEntities.Users; }            
        }

        public bool CreateUser(User instance)
        {            
            DBEntities.Users.Add(instance);
            DBEntities.SaveChanges();
            
            return true;
        }

        public bool UpdateUser(User instance)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(int userID)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            var userByEmail = DBEntities.Users.Where(u => String.Compare(u.Email, email) == 0).FirstOrDefault();
            return userByEmail;
        }

        public User GetUser(int id)
        {
            var userByID = DBEntities.Users.Where(u => u.ID == id).FirstOrDefault();

            return userByID;
        }

        public string GetUserRole(User currUser)
        {            
            string userRole = DBEntities.UserRoles.Where(r => r.ID == currUser.User_Role).FirstOrDefault().Name;

            return userRole;
        }
        public User Login(string email, string password)
        {            
            var logUser = DBEntities.Users.FirstOrDefault(u => string.Compare(u.Email, email, true) == 0
                                                               && u.Password == password);
            return logUser;
        }
        public User Login(string email)
        {
            var logUser = DBEntities.Users.FirstOrDefault(u => string.Compare(u.Email, email, true) == 0);

            return logUser;
        }
    }
}