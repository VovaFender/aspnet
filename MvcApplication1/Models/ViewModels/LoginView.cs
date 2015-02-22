using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models.ViewModels
{    
    public class LoginView
    {
        [Required(ErrorMessage = "enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "enter password")]        
        public string Password { get; set; }
    
        public bool IsPersistent { get; set; }
    }
}