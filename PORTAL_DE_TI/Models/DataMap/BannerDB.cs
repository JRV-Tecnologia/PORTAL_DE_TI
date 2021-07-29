using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_BANNER")]
    public class BannerDB
    {
        [Column("ID")]
        public Int32 Id { get; set; }
        [Column("BANNER")]
        public String Banner { get; set; }
        [Column("TOOLTIP")]
        public String Tooltip { get; set; }
        [Column("CAMINHO_IMG")]
        public String CaminhoImg { get; set; }
        [Column("BANNER_DET")]
        public String BannerDet { get; set; }
        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
        [Column("LINK")]
        public String Link { get; set; }

    }
}

