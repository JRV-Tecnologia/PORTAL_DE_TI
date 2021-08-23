using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PORTAL_DE_TI.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;

namespace PORTAL_DE_TI.Controllers
{
    public class NewsController : PrivateController
    {
        const string REPOSITORY = "/repository/news";
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsDB newsDB, List<IFormFile> caminhoImg)
        {
            var directorPath = MapPath($"/wwwroot{REPOSITORY}");
            if (!Directory.Exists(directorPath))
            {
                Directory.CreateDirectory(directorPath);
            }
            
            foreach (var formFile in caminhoImg)
            {
                if (formFile.Length > 0)
                {
                    FileInfo info = new FileInfo(formFile.FileName);
                    using (var stream = new FileStream(directorPath + info.Name, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    newsDB.CaminhoImg = $"{REPOSITORY}/{info.Name}";
                }
            }
            newsDB.DataCadastro = DateTime.Now;
            newsDB.Removed = false;
            this.News.Add(newsDB);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            NewsDB newsDB = this.News.Find(id);
            return View(newsDB);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewsDB newsDB, List<IFormFile> caminhoImg)
        {
            var directorPath = MapPath($"/wwwroot{REPOSITORY}");
            if (!Directory.Exists(directorPath))
            {
                Directory.CreateDirectory(directorPath);
            }

            foreach (var formFile in caminhoImg)
            {
                if (formFile.Length > 0)
                {
                    FileInfo info = new FileInfo(formFile.FileName);
                    string filePath = MapPath($"/wwwroot/{newsDB.CaminhoImg}");
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    using (var stream = new FileStream(directorPath + info.Name, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    newsDB.CaminhoImg = $"{REPOSITORY}/{info.Name}";
                }
            }
            this.News.Edit(newsDB);
            return View();
        }
    }
}

