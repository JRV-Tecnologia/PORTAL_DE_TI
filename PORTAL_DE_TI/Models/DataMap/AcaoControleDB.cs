using PORTAL_DE_TI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models

{
    [Table("TB_ACAO_CONTROLE")]
    public class AcaoControleDB
    {
        //properties
        [Key]
        [Column("ID_ACAO")]
        public Int32 AcaoDBId { get; set; }
        public AcaoDB AcaoDB { get; set; }
  
        [Key]
        [Column("ID_CONTROLE")]
        public Int32 ControleDBId { get; set; }
        public ControleDB ControleDB { get; set; }
    }
}
