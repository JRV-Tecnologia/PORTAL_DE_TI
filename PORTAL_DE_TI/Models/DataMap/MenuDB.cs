using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_MENU")]
    public class MenuDB
    {
        [Column("ID")]
        public Int32 Id { get; set; }
        [Column("ID_PAI")]
        public Int32? IdPai { get; set; }
        [Column("NOME")]
        public String Nome { get; set; }
        [Column("TOOLTIP")]
        public String Tooltip { get; set; }
        [Column("LINK")]
        public String Link { get; set; }
        [Column("ORDEM")]
        public Int32 Ordem { get; set; }
    }
}
