using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Global.Auth
{
    public class AuthHttpModule : IHttpModule
    {
        private NLog.Logger logger;

        public void Init(HttpApplication context)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
            
            logger.Info("auth module created!");

            context.AuthenticateRequest += new EventHandler(this.Authenticate);            
        }

        private void Authenticate(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication) sender;
            HttpContext context = app.Context;

            logger.Info("context inited!");

            var auth = DependencyResolver.Current.GetService<IAuthentication>();
            auth.HttpContext = context;
            context.User = auth.CurrentUser;
        }

        public void Dispose()
        {            
        }
    }
}