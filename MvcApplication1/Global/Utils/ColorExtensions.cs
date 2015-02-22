using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Global.Utils
{
    public static class ColorExtensions
    {
        public static int LetterCount(this String str)
        {
            return str.Length;
        }
    }
}