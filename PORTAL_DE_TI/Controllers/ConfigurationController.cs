using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PORTAL_DE_TI.Models;

namespace PORTAL_DE_TI.Controllers
{
    public class ConfigurationController : PrivateController
    {
        public IActionResult Index()
        {
            ViewBag.Usuarios = db.UsuarioDBs.OrderByDescending(b => b.NomeCompleto).Where(n => n.Removed == false).ToList();
            ViewBag.Controles = db.ControleDBs.OrderBy(b => b.Id).ToList();
            return View();
        }
    }
}
