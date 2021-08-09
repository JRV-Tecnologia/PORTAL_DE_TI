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
            perfilAcaoDB.PerfilUsuarioDB = db.PerfilUsuarioDBs.Find(perfilAcaoDB.PerfilUsuarioDBId);
            perfilAcaoDB.PerfilUsuarioDB.PerfilDB = db.PerfilDBs.Find(perfilAcaoDB.PerfilUsuarioDB.PerfilDBId);
            perfilAcaoDB.PerfilUsuarioDB.UsuarioDB = db.UsuarioDBs.Find(perfilAcaoDB.PerfilUsuarioDB.UsuarioDBId);


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
                perfilAcaoDB.PerfilUsuarioDB = db.PerfilUsuarioDBs.Find(perfilAcaoDB.PerfilUsuarioDBId);
                perfilAcaoDB.PerfilUsuarioDB.PerfilDB = db.PerfilDBs.Find(perfilAcaoDB.PerfilUsuarioDB.PerfilDBId);
                perfilAcaoDB.PerfilUsuarioDB.UsuarioDB = db.UsuarioDBs.Find(perfilAcaoDB.PerfilUsuarioDB.UsuarioDBId);

            }

            return perfilAcaoDBs;
        }


        public List<PerfilAcaoDB> FindAll(UsuarioDB usuario)
        {
           
            return this.FindAll().Where(w => w.PerfilUsuarioDB.UsuarioDBId == usuario.Id).ToList();
        }


        public bool HasAccess(string controller, string action, UsuarioDB usuarioDB)
        {
            List<PerfilAcaoDB> perfilAcaoDBs = this.FindAll();

            return perfilAcaoDBs.Where(w => w.MenuDB.ControleDBId != null).Any(
                a => a.AcaoDB.DsAction == action & 
                a.MenuDB.ControleDB.DsController == controller &
                a.PerfilUsuarioDB.UsuarioDBId == usuarioDB.Id);
        }
    }
}
