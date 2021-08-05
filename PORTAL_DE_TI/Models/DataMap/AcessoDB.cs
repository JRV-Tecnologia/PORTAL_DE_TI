using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PORTAL_DE_TI.Models
{
    [Table("TB_ACESSOS")]
    public class AcessoDB
    {
        [Column("ID_USUARIO")]
        public Int32 Id { get; set; }
        [Column("DATA_HORA")]
        public DateTime DataHora { get; set; }
        [Column("ID_CONTROLE")]
        public String IdControle { get; set; }
        [Column("ID_ACAO")]
        public String IdAcao { get; set; }
    }
}

