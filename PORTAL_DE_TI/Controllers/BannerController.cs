using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PORTAL_DE_TI.Models;

namespace PORTAL_DE_TI.Controllers
{
    public class BannerController : PrivateController
    {
        public IActionResult Detail(int id)
        {
            BannerDB banner = db.BannerDBs.First(f => f.Id == id & !f.Removed);

            return View("Detalhes", banner);
        }
    }
}
