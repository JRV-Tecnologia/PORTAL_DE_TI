using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PORTAL_DE_TI.Models
{
    [Table("TB_ACAO")]
    public class AcaoDB
    {
        
        [Column("ID_ACAO")]
        public Int32 Id { get; set; }
        [Column("DS_ACAO")]
        public String DsAcao { get; set; }
        [Column("DS_ACTION")]
        public String DsAction { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}
