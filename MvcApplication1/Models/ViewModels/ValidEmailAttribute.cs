using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MvcApplication1.Models.ViewModels
{
    //email validation attribute for email
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;                
            }

            if (!(value is string))
            {
                return false;
            }

            var source = value as string;
            if (String.IsNullOrWhiteSpace(source))
            {
                return false;
            }

            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);
            var match = regex.Match(source);

            //return true if everything is OK
            return (match.Success && match.Length == source.Length);
        }
    }
}