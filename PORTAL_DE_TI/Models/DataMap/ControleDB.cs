using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PORTAL_DE_TI.Models
{
    [Table("TB_CONTROLE")]
    public class ControleDB
    {
        [Key]
        [Column("ID")]
        public Int32 Id { get; set; }
        [Column("DS_CONTROLLER")]
        public String DsController { get; set; }
    }
}
