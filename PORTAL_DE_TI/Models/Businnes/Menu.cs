using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models.Businnes
{     
    public class Menu
    {
        private PortalContext db = new PortalContext();

        public Menu(PortalContext dbContext)
        {
            db = dbContext;
        }
        public MenuDB Find(int id)
        {
            MenuDB menu = db.MenuDBs.Find(id);
            menu.ControleDB = db.ControleDBs.Find(menu.ControleDBId);

            return menu;
        }

        public List<MenuDB> FindAll()
        {
            List<MenuDB> menuDBs = db.MenuDBs.ToList();

            foreach (MenuDB menuDB in menuDBs)
            {
                menuDB.ControleDB = db.ControleDBs.Find(menuDB.ControleDBId.Value);
            }           

            return menuDBs;
        }

    }
}
