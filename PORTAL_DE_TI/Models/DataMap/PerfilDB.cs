using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_PERFIL")]
    public class PerfilDB
    {
        [Column("ID_PERFIL")]
        public Int32 IdPerfil { get; set; }
        [Column("DS_PERFIL")]
        public String DsPerfil { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}
