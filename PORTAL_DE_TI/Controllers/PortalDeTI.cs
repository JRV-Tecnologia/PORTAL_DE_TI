using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PORTAL_DE_TI.Models;

namespace PORTAL_DE_TI.Controllers
{
    public class PortalDeTI : Controller
    {
        public IActionResult Index()
        {
            PortalContext db = new PortalContext();

            List<NewsDB> news = db.NewsDBs.ToList();

            ViewBag.News = news;

            return View();
        }
    }
}
