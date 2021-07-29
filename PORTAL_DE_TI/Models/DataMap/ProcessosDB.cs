using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_PROCESSOS")]
    public class ProcessosDB
    {
        [Column("ID")]
        public Int32 Id { get; set; }
        [Column("PROCESSO")]
        public String Processo { get; set; }
        [Column("TOOLTIP")]
        public String Tooltip { get; set; }
        [Column("PROCESSO_DET")]
        public String ProcessoDet { get; set; }
        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
    }
}
