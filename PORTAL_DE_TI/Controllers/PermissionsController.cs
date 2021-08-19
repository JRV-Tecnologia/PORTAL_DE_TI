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
    public class PermissionsController : PrivateController
    {
        [HttpGet]
        public ActionResult Index(int id, string type)
        {
            switch (type)
            {
                case "user":
                    var usr = this.UsuarioAcao.FindUserPermissions(id);
                    return Json(usr.Select(s => new {
                        s.AcaoDBId,
                        s.MenuDB.ControleDBId,
                        s.UsuarioDBId
                    }));
                case "group":
                    var grp = this.PerfilAcao.FindGroupPermissions(id);
                    return Json(grp.Select(s => new {
                        s.AcaoDBId,
                        s.MenuDB.ControleDBId,
                        s.PerfilDBId
                    }));
                case "member":
                    var mbr = this.PerfilUsuario.FindMemberPermissions(id);
                    return Json(mbr.Select(s => new {
                        s.PerfilDBId,
                        s.PerfilDB.DsPerfil,
                        s.UsuarioDBId,
                        s.UsuarioDB.NomeCompleto
                    }));
                case "allUsers":
                    var allUsers = this.Usuario.FindAll(Request.Query["qry"].ToString());
                    return Json(allUsers.Select(s => new {
                        value = s.Id,
                        text = s.NomeCompleto
                    }));
            }

            return null;
        }

        [HttpPost]
        public JsonResult Edit(int id, string type)
        {
            List<ControleDB> controles = this.Controle.FindAll();

            switch (type)
            {
                case "user":                  
                    

                    foreach (ControleDB controle in controles)
                    {
                        foreach (AcaoControleDB acaoControle in controle.AcaoControleList)
                        {
                            string permissao = $"prm-usr-{acaoControle.AcaoDBId}-{controle.Id}";

                            if (Request.Form[permissao].Any() && !String.IsNullOrEmpty(Request.Form[permissao]))
                            {
                                bool acaoPermitida = Request.Form[permissao].ToString() == "1";

                                if (acaoPermitida)
                                {
                                    this.UsuarioAcao.Add(new UsuarioAcaoDB()
                                    {
                                        AcaoDBId = acaoControle.AcaoDBId,
                                        MenuDBId = controle.MenuDB.Id,
                                        UsuarioDBId = id
                                    });
                                }
                                else
                                {
                                    this.UsuarioAcao.Remove(new UsuarioAcaoDB()
                                    {
                                        AcaoDBId = acaoControle.AcaoDBId,
                                        MenuDBId = controle.MenuDB.Id,
                                        UsuarioDBId = id
                                    });
                                }
                            }
                        }
                    }


                    break;
                case "group":                 

                    foreach (ControleDB controle in controles)
                    {
                        foreach (AcaoControleDB acaoControle in controle.AcaoControleList)
                        {
                            string permissao = $"prm-grp-{acaoControle.AcaoDBId}-{controle.Id}";

                            if (Request.Form[permissao].Any() && !String.IsNullOrEmpty(Request.Form[permissao]))
                            {
                                bool acaoPermitida = Request.Form[permissao].ToString() == "1";

                                if (acaoPermitida)
                                {
                                    this.PerfilAcao.Add(new PerfilAcaoDB()
                                    {
                                        AcaoDBId = acaoControle.AcaoDBId,
                                        MenuDBId = controle.MenuDB.Id,
                                        PerfilDBId = id
                                    });
                                }
                                else
                                {
                                    this.PerfilAcao.Remove(new PerfilAcaoDB()
                                    {
                                        AcaoDBId = acaoControle.AcaoDBId,
                                        MenuDBId = controle.MenuDB.Id,
                                        PerfilDBId = id
                                    });
                                }
                            }
                        }
                    }

                    break;
                case "member":

                    if (Request.Form["user-members"].Any() && !String.IsNullOrEmpty(Request.Form["user-members"]))
                    {

                        String[] users = Request.Form["user-members"];

                        foreach(string user in users)
                        {
                            this.PerfilUsuario.Add(Convert.ToInt32(user), id);
                        }

                    }

                    break;

            }

            


           

            return Json(null);
        }

    }
}
