using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using PORTAL_DE_TI.Services;

namespace PORTAL_DE_TI.Models.Businnes
{
    public class Controle
    {
        private PortalContext db;

        public Controle(PortalContext dbContext)
        {
            db = dbContext;
        }


        public List<ControleDB> FindAll()
        {
            List<ControleDB> list = db.ControleDBs.ToList();

            foreach (ControleDB controle in list)
            {
                controle.AcaoControleList = db.AcaoControleDBs.Where(w => w.ControleDBId == controle.Id).ToList();
                controle.MenuDB = db.MenuDBs.FirstOrDefault(f => f.ControleDBId == controle.Id);
            }

            return list;
        }
    }
}
