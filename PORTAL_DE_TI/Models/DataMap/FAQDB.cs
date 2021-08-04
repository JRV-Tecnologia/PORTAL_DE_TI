using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_FAQ")]
    public class FAQDB
    {
        [Column("ID")]
        public Int32 Id { get; set; }
        [Column("FAQ")]
        public String FAQ { get; set; }
        [Column("TOOLTIP")]
        public String Tooltip { get; set; }
        [Column("CAMINHO_IMG")]
        public String CaminhoImg { get; set; }
        [Column("FAQ_DET")]
        public String FAQDet { get; set; }
    }
}

