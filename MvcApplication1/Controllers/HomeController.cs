using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.EntityClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using MvcApplication1.App_Start;
using MvcApplication1.Global;
using MvcApplication1.Models;
using Ninject;

namespace MvcApplication1.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        [Inject]
        public MvcApplication1.App_Start.NinjectWebCommon.IWeapon weapon { get; set; }
        
        [Inject]
        public IUserRepository Repository { get; set; }
        
        public ActionResult Index()
        {
            ViewBag.CurrentUser = CurrentUser;

            return View(weapon);
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

        public ActionResult TriangleSquare(int a, int h, string color)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();            

            float square = (float) 0.5*a*h;
            ViewBag.Color = color;
            
            return View(square);

        }
    }
}
