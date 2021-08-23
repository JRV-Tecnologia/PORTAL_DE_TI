using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models.Businnes
{     
    public class News
    {
        private PortalContext db;

        public News(PortalContext dbContext)
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

        public List<NewsDB> FindAll()
        {
            List<NewsDB> newsDBs = db.NewsDBs.ToList();

            return newsDBs;
        }

        public NewsDB Find(int id)
        {
            return db.NewsDBs.FirstOrDefault(f => f.Id == id);

        }

        public void Add(NewsDB newsDB)
        {
            if (!db.NewsDBs.Any(a => a.Nome == newsDB.Nome))
            {
                db.NewsDBs.Add(newsDB);
            }

            db.SaveChanges();
        }

        public void Remove(NewsDB newsDB)
        {
            if (db.NewsDBs.Any(a => a.Id == newsDB.Id))
            {
                db.NewsDBs.Remove(db.NewsDBs.First(f => f.Id == newsDB.Id));
            }
            db.SaveChanges();
        }

        public void Edit(NewsDB newsDB)
        {
            if (db.NewsDBs.Any(a => a.Id == newsDB.Id))
            {
                NewsDB retorno = db.NewsDBs.First(f => f.Id == newsDB.Id);
                retorno.Nome = newsDB.Nome;
                retorno.Resenha = newsDB.Resenha;
                retorno.Texto = newsDB.Texto;
                retorno.CaminhoImg = newsDB.CaminhoImg;
            }

            db.SaveChanges();
        }
    }
}
