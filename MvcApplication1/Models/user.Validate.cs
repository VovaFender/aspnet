//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Web;
//using System.Web.Mvc;
//using MvcApplication1.Models;
//
//namespace MvcApplication1.Models
//{
//
//    public partial class user : IValidatableObject
//    {
//        public string ConfirmPassword { get; set; }
//
//        public string Captcha { get; set; }
//        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
//        {
//            if (string.IsNullOrWhiteSpace(email))
//            {
//                yield return new ValidationResult("Enter email", new string[] { "Email" } );
//            }
//
//            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);
//            var match = string.IsNullOrWhiteSpace(email) ? regex.Match("hui") : regex.Match(email);
//
//            if (!(match.Success && match.Length == email.Length))
//            {
//                yield return new ValidationResult("Enter correct email", new string[] { "Email" });
//            }
//
//            if (string.IsNullOrWhiteSpace(password))
//            {
//                yield return new ValidationResult("Enter password", new string[] { "Password" });
//            }
//
//            if (password != ConfirmPassword)
//            {
//                yield return new ValidationResult("Passwords do not match", new string[] { "ConfirmPassword" });
//            }
//                        
//        }
//    }
//}