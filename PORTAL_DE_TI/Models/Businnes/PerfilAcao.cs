using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models.Businnes
{     
    public class PerfilAcao
    {
        private PortalContext db;

        public PerfilAcao(PortalContext dbContext)
        {
            db = dbContext;
        }
        public PerfilAcaoDB Find(int id)
        {
            PerfilAcaoDB perfilAcaoDB = db.PerfilAcaoDBs.Find(id);
            perfilAcaoDB.AcaoDB = db.AcaoDBs.Find(perfilAcaoDB.AcaoDBId);
            perfilAcaoDB.MenuDB = db.MenuDBs.Find(perfilAcaoDB.MenuDBId);
            perfilAcaoDB.PerfilDB = db.PerfilDBs.Find(perfilAcaoDB.PerfilDBId);
           // perfilAcaoDB.PerfilDB.UsuarioDB = db.UsuarioDBs.Find(perfilAcaoDB.PerfilUsuarioDB.UsuarioDBId);


            return perfilAcaoDB;
        }

        public List<PerfilAcaoDB> FindAll()
        {
            List<PerfilAcaoDB> perfilAcaoDBs = db.PerfilAcaoDBs.ToList();

            foreach (PerfilAcaoDB perfilAcaoDB in perfilAcaoDBs)
            {
                perfilAcaoDB.AcaoDB = db.AcaoDBs.Find(perfilAcaoDB.AcaoDBId);
                perfilAcaoDB.MenuDB = db.MenuDBs.Find(perfilAcaoDB.MenuDBId);
                perfilAcaoDB.MenuDB.ControleDB = db.ControleDBs.Find(perfilAcaoDB.MenuDB.ControleDBId);
                perfilAcaoDB.PerfilDB = db.PerfilDBs.Find(perfilAcaoDB.PerfilDBId);
                perfilAcaoDB.PerfilDB.PerfilUsuarioDBList = db.PerfilUsuarioDBs.Where( w=> w.PerfilDBId == perfilAcaoDB.PerfilDBId).ToList();

            }

            return perfilAcaoDBs;
        }


        public List<PerfilAcaoDB> FindAll(UsuarioDB usuario)
        {
           
            return this.FindAll().Where(w => w.PerfilDB.PerfilUsuarioDBList.Any(a => a.UsuarioDBId == usuario.Id)).ToList();
        }


        public bool HasAccess(string controller, string action, UsuarioDB usuarioDB)
        {
            List<PerfilAcaoDB> perfilAcaoDBs = this.FindAll();

            return perfilAcaoDBs.Where(w => w.MenuDB.ControleDBId != null).Any(
                a => a.AcaoDB.DsAction == action & 
                a.MenuDB.ControleDB.DsController == controller &
                a.PerfilDB.PerfilUsuarioDBList.Any(pu => pu.UsuarioDBId == usuarioDB.Id));
        }


        public List<PerfilAcaoDB> FindGroupPermissions(int group)
        {
            return this.FindAll().Where(w => w.PerfilDBId == group).ToList();
        }

        public void Add(PerfilAcaoDB perfilAcaoDB)
        {
            if (!db.PerfilAcaoDBs.Any(a => a.AcaoDBId == perfilAcaoDB.AcaoDBId & a.MenuDBId == perfilAcaoDB.MenuDBId & a.PerfilDBId == perfilAcaoDB.IdPerfilAcao))
            {
                db.PerfilAcaoDBs.Add(perfilAcaoDB);
            }

            db.SaveChanges();
        }

        public void Remove(PerfilAcaoDB perfilAcaoDB)
        {
            if (db.PerfilAcaoDBs.Any(a => a.AcaoDBId == perfilAcaoDB.AcaoDBId & a.MenuDBId == perfilAcaoDB.MenuDBId & a.PerfilDBId == perfilAcaoDB.PerfilDBId))
            {
                db.PerfilAcaoDBs.Remove(db.PerfilAcaoDBs.First(a => a.AcaoDBId == perfilAcaoDB.AcaoDBId & a.MenuDBId == perfilAcaoDB.MenuDBId & a.PerfilDBId == perfilAcaoDB.PerfilDBId));
            }
            db.SaveChanges();
        }
    }
}
