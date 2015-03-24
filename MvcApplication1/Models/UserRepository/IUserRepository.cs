using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcApplication1.Models;
using System.Web.Providers.Entities;

namespace MvcApplication1.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; } 

        bool CreateUser(User instance);

        bool UpdateUser(User instance);

        bool RemoveUser(int userID);

        User GetUser(string email);

        User GetUser(int id);
        User Login(string email, string password);

        User Login(string email);
        string GetUserRole(User currUser);
    }
}
