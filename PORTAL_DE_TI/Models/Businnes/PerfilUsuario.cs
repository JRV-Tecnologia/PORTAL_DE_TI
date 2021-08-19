using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models.Businnes
{     
    public class PerfilUsuario
    {
        private PortalContext db;

        public PerfilUsuario(PortalContext dbContext)
        {
            db = dbContext;
        }
       

        public List<PerfilUsuarioDB> FindAll()
        {
            List<PerfilUsuarioDB> perfilUsuarioDBs = db.PerfilUsuarioDBs.ToList();

            foreach (PerfilUsuarioDB perfilUsuarioDB in perfilUsuarioDBs)
            {
                perfilUsuarioDB.PerfilDB = db.PerfilDBs.Find(perfilUsuarioDB.PerfilDBId);
                perfilUsuarioDB.UsuarioDB = db.UsuarioDBs.Find(perfilUsuarioDB.UsuarioDBId);
               
            }

            return perfilUsuarioDBs;
        }


        public List<PerfilUsuarioDB> FindMemberPermissions(int perfil)
        {
            return this.FindAll().Where(w => w.PerfilDBId == perfil).ToList();
        }

        public void Add(int usuario, int perfil)
        {
            if (!db.PerfilUsuarioDBs.Any(a => a.UsuarioDBId == usuario & a.PerfilDBId == perfil))
            {
                db.PerfilUsuarioDBs.Add(new PerfilUsuarioDB() { UsuarioDBId = usuario, PerfilDBId = perfil});
            }

            db.SaveChanges();
        }

        public void Remove(PerfilUsuarioDB perfilUsuarioDB)
        { 
            if (db.PerfilUsuarioDBs.Any(a => a.UsuarioDBId == perfilUsuarioDB.UsuarioDBId & a.PerfilDBId == perfilUsuarioDB.PerfilDBId))
            {
                db.PerfilUsuarioDBs.Remove(db.PerfilUsuarioDBs.First(a => a.UsuarioDBId == perfilUsuarioDB.UsuarioDBId & a.PerfilDBId == perfilUsuarioDB.PerfilDBId));
            }
            db.SaveChanges();
        }
    }
}
