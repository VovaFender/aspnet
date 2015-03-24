using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcApplication1.Models;

namespace MvcApplication1.Global.Auth
{
    interface IUserProvider
    {
        User User { get; set; }
    }
}
