using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using MvcApplication1.Global;
using MvcApplication1.Models.ViewModels;
using LoginView = MvcApplication1.Models.ViewModels.LoginView;

namespace MvcApplication1.Controllers
{
    public class LoginController : BaseController
    {       
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Login(LoginView view)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(view.Email, view.Password, view.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState["Password"].Errors.Add("Passwords do not match");
                }
            }
            return View(view);
        }
       
        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }

    }
}