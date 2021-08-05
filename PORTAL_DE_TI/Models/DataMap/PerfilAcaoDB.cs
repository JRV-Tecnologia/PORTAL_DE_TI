using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_PERFIL_ACAO")]
    public class PerfilAcaoDB
    {
        [Key]
        [Column("ID_PERFIL_ACAO")]
        public Int32 IdPerfilAcao { get; set; }
        [Column("ID_ACAO")]
        public Int32 IdAcao { get; set; }
        [Column("ID_PERFIL")]
        public Int32 IdPerfil { get; set; }
        [Column("ID_MENU")]
        public Int32 IdMenu { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}
