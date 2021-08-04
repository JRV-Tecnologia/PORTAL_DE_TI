using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PORTAL_DE_TI.Models
{
    [Table("TB_TIPO_ACAO")]
    public class TipoAcaoDB
    {
        [Column("ID_TIPO_ACAO")]
        public Int32 IdTipoAcao { get; set; }
        [Column("DS_TIPO_ACAO")]
        public String DsTipoAcao { get; set; }
        [Column("ID_ACAO")]
        public Int32 IdAcao { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}
