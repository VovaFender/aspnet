using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models.ViewModels
{
    public class ViewUser
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = "Enter email")]
        [ValidEmail(ErrorMessage = "Email is invalid")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "Enter password")]
        [MinLength(6, ErrorMessage = "Password too short")]
        public string password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "Passwords do not match")]
        public string confirmPassword { get; set; }

        public int user_role { get; set; }

        public int BirthDateDay { get; set; }

        public int BirthDateMonth { get; set; }

        public int BirthDateYear { get; set; }

        public IEnumerable<SelectListItem> BirthDateDayListItems
        {
            get
            {                
                for (int i = 1; i < 32; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = false
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> BirthDateMonthListItems
        {
            get
            {
                for (int i = 1; i < 13; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = new DateTime(DateTime.Now.Year, i, 1).ToString("MMMMM"),
                        Selected = false
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> BirthDateYearListItems
        {
            get
            {
                for (int i = 1940; i < DateTime.Now.Year; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = false
                    };
                }
            }
        }
    }
}