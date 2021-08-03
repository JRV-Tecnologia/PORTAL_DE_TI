using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_BANNER4")]
    public class Banner4DB
    {
        [Column("ID")]
        public Int32 Id { get; set; }
        [Column("BANNER4")]
        public String Banner4 { get; set; }
        [Column("TOOLTIP")]
        public String Tooltip { get; set; }
        [Column("CAMINHO_IMG")]
        public String CaminhoImg { get; set; }
        [Column("BANNER4_DET")]
        public String Banner4Det { get; set; }
        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
        [Column("LINK")]
        public String Link { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}

