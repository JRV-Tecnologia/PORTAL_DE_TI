using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_PERFIL_USUARIO")]
    public class PerfilUsuarioDB
    {
        [Column("ID_PERFIL_USUARIO")]
        public Int32 IdPerfilUsuario { get; set; }
        [Column("ID_USUARIO")]
        public Int32 IdUsuario { get; set; }
        [Column("ID_PERFIL")]
        public Int32 IdPerfil { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}

