using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PORTAL_DE_TI.Controllers
{
    public class DetalhesController : PrivateController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
