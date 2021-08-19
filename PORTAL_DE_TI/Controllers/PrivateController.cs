using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PORTAL_DE_TI.Models;
using PORTAL_DE_TI.Models.Businnes;

namespace PORTAL_DE_TI.Controllers
{
    public class PrivateController : Controller
    {
        private const string PUBLIC_REDIRECT = "/Authentication/Login";
        private const string PRIVATE_REDIRECT = "/";

        public PortalContext db = new PortalContext();

        private UsuarioDB usuarioDB;
        public UsuarioDB UsuarioLogado {
            get
            {
                return usuarioDB;
            }
         }

        public PerfilAcao PerfilAcao { get; set; }
        public PerfilUsuario PerfilUsuario { get; set; }
        public UsuarioAcao UsuarioAcao { get; set; }
        public Usuario Usuario { get; set; }
        public AcaoControle AcaoControle { get; set; }
        public Controle Controle { get; set; }

        public PrivateController()
        {
            UsuarioAcao = new UsuarioAcao(db);
            PerfilUsuario = new PerfilUsuario(db);
            PerfilAcao = new PerfilAcao(db);
            Usuario = new Usuario(db);
            AcaoControle = new AcaoControle(db);
            Controle = new Controle(db);

        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                usuarioDB = this.Usuario.Authentication(filterContext.HttpContext);

                if (usuarioDB == null)
                {
                    filterContext.Result = new RedirectResult(PUBLIC_REDIRECT);
                    return;
                }


                string controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ControllerName;
                string actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName;

                bool access = this.PerfilAcao.HasAccess(controllerName, actionName, usuarioDB);

                if (!access)
                {
                    filterContext.Result = new RedirectResult(PRIVATE_REDIRECT);
                    return;
                }

                ViewData["UsuarioLogado"] = usuarioDB;

                ViewData["Permissões"] = this.PerfilAcao.FindAll(usuarioDB);

                  
            }
            catch(Exception Ex)
            {

                filterContext.Result = new RedirectResult(PUBLIC_REDIRECT);
                return;
            }
            base.OnActionExecuting(filterContext);





            ViewData["Menu"] = db.MenuDBs.ToList();
        }



    }
}
