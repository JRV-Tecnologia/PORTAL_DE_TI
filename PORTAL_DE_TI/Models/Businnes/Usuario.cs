using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using PORTAL_DE_TI.Services;

namespace PORTAL_DE_TI.Models.Businnes
{
    public class Usuario
    {
        private PortalContext db;

        public Usuario(PortalContext dbContext)
        {
            db = dbContext;
        }

        public UsuarioDB Authentication(HttpContext context)
        {
            try
            {
                UserADcs userADcs = new UserADcs();

                IHttpContextAccessor contextAccessor = new HttpContextAccessor();
                contextAccessor.HttpContext = context;

                UsuarioDB usuario = userADcs.BuscaIdUsuario(new UserResolverService(contextAccessor));

                ///TODO: verificar se usuario existe no banco de dados

                // usuario = db.UsuarioDBs.FirstOrDefault(f => f.Login == usuario.Login);
                 usuario = db.UsuarioDBs.FirstOrDefault(f => f.Id == 1);


                return usuario;

            }
            catch (Exception Ex)
            {
                return null;
            } 
        }

        public List<UsuarioDB> FindAll()
        {
            List<UsuarioDB> list = db.UsuarioDBs.ToList();

            foreach (UsuarioDB usuario in list)
            {
                usuario.PerfilUsuarioDBList = db.PerfilUsuarioDBs.Where(w => w.UsuarioDBId == usuario.Id).ToList();
            }

            return list;
        }
        public List<UsuarioDB> FindAll(string filter)
        {
            List<UsuarioDB> list = db.UsuarioDBs.Where(w => w.NomeCompleto.Contains(filter)).ToList();

            foreach (UsuarioDB usuario in list)
            {
                usuario.PerfilUsuarioDBList = db.PerfilUsuarioDBs.Where(w => w.UsuarioDBId == usuario.Id).ToList();
            }

            return list;
        }


    }
}
