using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models.Businnes
{     
    public class UsuarioAcao
    {
        private PortalContext db;

        public UsuarioAcao(PortalContext dbContext)
        {
            db = dbContext;
        }
        //public PerfilAcaoDB Find(int id)
        //{
        //    PerfilAcaoDB perfilAcaoDB = db.PerfilAcaoDBs.Find(id);
        //    perfilAcaoDB.AcaoDB = db.AcaoDBs.Find(perfilAcaoDB.AcaoDBId);
        //    perfilAcaoDB.MenuDB = db.MenuDBs.Find(perfilAcaoDB.MenuDBId);
        //    perfilAcaoDB.PerfilUsuarioDB = db.PerfilUsuarioDBs.Find(perfilAcaoDB.PerfilUsuarioDBId);
        //    perfilAcaoDB.PerfilUsuarioDB.PerfilDB = db.PerfilDBs.Find(perfilAcaoDB.PerfilUsuarioDB.PerfilDBId);
        //    perfilAcaoDB.PerfilUsuarioDB.UsuarioDB = db.UsuarioDBs.Find(perfilAcaoDB.PerfilUsuarioDB.UsuarioDBId);


        //    return perfilAcaoDB;
        //}

        public List<UsuarioAcaoDB> FindAll()
        {
            List<UsuarioAcaoDB> usuarioAcaoDBs = db.UsuarioAcaoDBs.ToList();

            foreach (UsuarioAcaoDB usuarioAcaoDB in usuarioAcaoDBs)
            {
                usuarioAcaoDB.AcaoDB = db.AcaoDBs.Find(usuarioAcaoDB.AcaoDBId);
                usuarioAcaoDB.MenuDB = db.MenuDBs.Find(usuarioAcaoDB.MenuDBId);
                usuarioAcaoDB.MenuDB.ControleDB = db.ControleDBs.Find(usuarioAcaoDB.MenuDB.ControleDBId);
                usuarioAcaoDB.UsuarioDB = db.UsuarioDBs.Find(usuarioAcaoDB.UsuarioDBId);
            }

            return usuarioAcaoDBs;
        }


        public List<UsuarioAcaoDB> FindUserPermissions(int controller, int user)
        {
            return this.FindAll().Where(w => w.UsuarioDBId == user & w.MenuDB.ControleDBId == controller).ToList();
        }

        public List<UsuarioAcaoDB> FindUserPermissions(int user)
        {
            return this.FindAll().Where(w => w.UsuarioDBId == user).ToList();
        }

        public void Add(UsuarioAcaoDB usuarioAcaoDB)
        {
            if (!db.UsuarioAcaoDBs.Any(a => a.AcaoDBId == usuarioAcaoDB.AcaoDBId & a.MenuDBId == usuarioAcaoDB.MenuDBId & a.UsuarioDBId == usuarioAcaoDB.UsuarioDBId))
            {
                db.UsuarioAcaoDBs.Add(usuarioAcaoDB);
            }

            db.SaveChanges();
        }

        public void Remove(UsuarioAcaoDB usuarioAcaoDB)
        {
            if (db.UsuarioAcaoDBs.Any(a => a.AcaoDBId == usuarioAcaoDB.AcaoDBId & a.MenuDBId == usuarioAcaoDB.MenuDBId & a.UsuarioDBId == usuarioAcaoDB.UsuarioDBId))
            {
                db.UsuarioAcaoDBs.Remove(db.UsuarioAcaoDBs.First(a => a.AcaoDBId == usuarioAcaoDB.AcaoDBId & a.MenuDBId == usuarioAcaoDB.MenuDBId & a.UsuarioDBId == usuarioAcaoDB.UsuarioDBId));
            }
            db.SaveChanges();
        }
    }
}
