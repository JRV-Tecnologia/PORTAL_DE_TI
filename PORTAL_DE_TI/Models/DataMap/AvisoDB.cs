using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_AVISOS")]
    public class AvisoDB
    {
        [Column("ID")]
        public Int32 Id { get; set; }
        [Column("AVISO")]
        public String Aviso { get; set; }
        [Column("TOOLTIP")]
        public String Tooltip { get; set; }
        [Column("AVISO_DET")]
        public String AvisoDet { get; set; }
    }
}
