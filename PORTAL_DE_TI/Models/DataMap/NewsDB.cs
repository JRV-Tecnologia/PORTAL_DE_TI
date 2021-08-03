using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_NEWS")]
    public class NewsDB
    {
        [Column("ID")]
        public Int32 Id { get; set; }
        [Column("NOME")]
        public String Nome { get; set; }
        [Column("RESENHA")]
        public String Resenha { get; set; }
        [Column("CAMINHO_IMG")]
        public String CaminhoImg { get; set; }
        [Column("TEXTO")]
        public String Texto { get; set; }
        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}
