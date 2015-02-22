using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcApplication1.Models;

namespace MvcApplication1.Models
{
 
    public interface IUserRepository
    {
        IQueryable<user> Users { get; } 

        bool CreateUser(user instance);

        bool UpdateUser(user instance);

        bool RemoveUser(int userID);

        user GetUser(string email);

        user GetUser(int id);
        user Login(string email, string password);

        user Login(string email);
        string GetUserRole(user currUser);
    }
}
