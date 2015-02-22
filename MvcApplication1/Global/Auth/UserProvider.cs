using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MvcApplication1.Models;
using Ninject;

namespace MvcApplication1.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIdentity userIdentity { get; set; }

        public UserProvider(string name, IUserRepository repository)
        {
            userIdentity = new UserIdentity();
            userIdentity.Init(name, repository);
        }

        public bool IsInRole(string checkRole)
        {
            if (userIdentity.User == null)
            {
                return false;
            }            
            return userIdentity.User.InRoles(checkRole);
        }

        public IIdentity Identity
        {
            get { return userIdentity; }
        }

        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}