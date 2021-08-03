using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PORTAL_DE_TI.Models;

namespace PORTAL_DE_TI.Controllers
{
    public class HighlightController : PrivateController
    {
        public IActionResult Detail(int id)
        {
            Banner4DB banner4 = db.Banner4DBs.First(f => f.Id == id & !f.Removed);

            return View("Detalhes", banner4);
        }
    }
}
