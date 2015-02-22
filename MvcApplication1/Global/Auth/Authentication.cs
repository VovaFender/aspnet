using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using MvcApplication1.Models;
using Ninject;

namespace MvcApplication1.Global.Auth
{
    public class Authentication : IAuthentication
    {
        
        [Inject]
        public IUserRepository Repository { get; set; }

        private const string cookieName = "__AUTH_COOKIE_ASP";
        
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public HttpContext HttpContext { get; set; }

        private IPrincipal _currentUser;
        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        //get cookie from request
                        var authCookie = HttpContext.Request.Cookies[cookieName];
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            //read cookie
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            //get user
                            _currentUser = new UserProvider(ticket.Name, Repository);
                        }
                        else
                        {                            
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed authentication" + ex.Message);
                        _currentUser = new UserProvider(null, null);
                    }
                }

                return _currentUser;
            }
            set { }
        }        
            
        #region IAuthentication Members

        public user Login(string login, string password, bool isPersistent)
        {
            user retUser = Repository.Login(login, password);

            if (retUser != null)
            {
                CreateCookie(login, isPersistent);
            }

            return retUser;
        }

        private void CreateCookie(string login, bool isPersistent = false)
        {
            //create ticket
            var ticket = new FormsAuthenticationTicket(
                1,
                login,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                string.Empty,
                FormsAuthentication.FormsCookiePath);

            //encrypt ticket
            var encrTicket = FormsAuthentication.Encrypt(ticket);
            
            //create cookie object
            var authCookie = new HttpCookie(cookieName)
            {
                Value = encrTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            
            //set cookie
            HttpContext.Response.Cookies.Set(authCookie);
        }

        public user Login(string login)
        {
            user retUser = Repository.Login(login);

            if (retUser != null)
            {
                CreateCookie(login);
            }

            return retUser;
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Request.Cookies.Get(cookieName);

            if (httpCookie != null)
            {
                httpCookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Response.Cookies.Add(httpCookie);
            }
        }

        #endregion      
    }
}