using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PORTAL_DE_TI.Models;

namespace PORTAL_DE_TI.Controllers
{
    public class NewsController : PrivateController
    {
        public IActionResult Index()
        {
            ViewBag.News = db.NewsDBs.OrderByDescending(b => b.DataCadastro).Where(n => n.Removed == false).ToList();

            return View();
        }

        public IActionResult Detail(int id)
        {
            NewsDB news = db.NewsDBs.First(f => f.Id == id & !f.Removed);

            return View("Detalhes", news);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
