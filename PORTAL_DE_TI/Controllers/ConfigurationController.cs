using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PORTAL_DE_TI.Models;
using PORTAL_DE_TI.Models.Businnes;

namespace PORTAL_DE_TI.Controllers
{
    public class ConfigurationController : PrivateController
    {
        public IActionResult Index()
        {
            ViewBag.Usuarios = db.UsuarioDBs.OrderByDescending(b => b.NomeCompleto).Where(n => n.Removed == false).ToList();
            ViewBag.Perfis = db.PerfilDBs.OrderByDescending(b => b.DsPerfil).Where(n => n.Removed == false).ToList();
            ViewBag.Controles = db.ControleDBs.OrderBy(b => b.Id).ToList();
            ViewBag.Permissoes = this.AcaoControle.FindAll();
            return View();
        }
    }
}
