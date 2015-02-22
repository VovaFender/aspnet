using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "users",
                url: "users",
                defaults: new { controller = "User", action = "Users" });

            routes.MapRoute(
                name: "UsersShow",
                url: "User/Show/{id}",
                defaults: new { controller = "User", action = "Users", id = UrlParameter.Optional },
                constraints: new { id = @"\d*" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}