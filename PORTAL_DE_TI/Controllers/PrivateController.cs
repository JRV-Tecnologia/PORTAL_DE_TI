using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PORTAL_DE_TI.Models;

namespace PORTAL_DE_TI.Controllers
{
    public class PrivateController : Controller    
    {
        public PortalContext db = new PortalContext();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData["Menu"] = db.MenuDBs.ToList();
        }
    }
}
