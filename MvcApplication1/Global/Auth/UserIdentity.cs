﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MvcApplication1.Models;

namespace MvcApplication1.Global.Auth
{
    public class UserIdentity : IIdentity, IUserProvider
    {
        public user User { get; set; }

        public string Name
        {
            get
            {
                if (IsAuthenticated)
                {
                    return User.email;
                }
                return "anonym";
            }            
        }

        public string AuthenticationType
        {
            get { return typeof (user).ToString(); }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public void Init(string email, IUserRepository repository)
        {
            if (!string.IsNullOrEmpty(email) && repository != null)
            {
                User = repository.GetUser(email);
            }
        }
    }
}