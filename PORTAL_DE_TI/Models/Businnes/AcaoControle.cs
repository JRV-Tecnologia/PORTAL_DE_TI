using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models.Businnes
{     
    public class AcaoControle
    {
        private PortalContext db;

        public AcaoControle(PortalContext dbContext)
        {
            db = dbContext;
        }
       
        public List<AcaoControleDB> FindAll()
        {
            List<AcaoControleDB> acaoControleDBs = db.AcaoControleDBs.ToList();

            foreach (AcaoControleDB acaoControleDB in acaoControleDBs)
            {
                acaoControleDB.AcaoDB = db.AcaoDBs.Find(acaoControleDB.AcaoDBId);
                acaoControleDB.ControleDB = db.ControleDBs.Find(acaoControleDB.ControleDBId);


            }

            return acaoControleDBs;
        }



    }
}
