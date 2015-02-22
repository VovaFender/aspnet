using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using MvcApplication1.Global.Auth;
using MvcApplication1.Mappers;
using MvcApplication1.Models;
using MvcApplication1.Models.ViewModels;
using Ninject;

namespace MvcApplication1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [Inject]
        public MvcApplication1.App_Start.NinjectWebCommon.IWeapon weapon { get; set; }

        [Inject]
        public IUserRepository Repository { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }

        public user CurrentUser
        {
            get { return ((UserIdentity) Auth.CurrentUser.Identity).User; }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users(int? id)
        {
            var users = new List<user>();

            if (id != null)
            {
                var user = Repository.GetUser((int) id);

                if (user == null)
                {
                    return HttpNotFound("User not found");
                }
                users.Add(user);
            }
            else
            {
                users = Repository.Users.ToList();
            }            
            return View(users);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var newViewUser = new ViewUser();

            return View(newViewUser);
        }

        [HttpPost]
        public ActionResult Register(ViewUser newViewUser)
        {

            var anyUser = Repository.GetUser(newViewUser.email);
            
            if (anyUser != null)
            {
                ModelState.AddModelError("Email", "User with this email already exists");
            }
          
            if (ModelState.IsValid)
            {
                newViewUser.user_role = 2;
                var newUser = (user)Mapper.Map(newViewUser, typeof(ViewUser), typeof(user));                
                //make him standard user                
                Repository.CreateUser(newUser);

                return RedirectToAction("Index");
            }
            return View(newViewUser);
        }
    }
}
