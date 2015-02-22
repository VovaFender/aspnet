using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Global.Auth;
using MvcApplication1.Models;
using Ninject;

namespace MvcApplication1.Global
{
    public class BaseController : Controller
    {
        [Inject]
        public IAuthentication Auth { get; set; }

        public user CurrentUser
        {
            get { return ((IUserProvider)Auth.CurrentUser.Identity).User; }
        }
        
    }
}