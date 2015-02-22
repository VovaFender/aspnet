using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Providers.Entities;
using MvcApplication1.Models;

namespace MvcApplication1.Global.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }
        IPrincipal CurrentUser { get; set; }
        user Login(string login, string password, bool isPersistent);

        user Login(string login);

        void LogOut();
    }
}
