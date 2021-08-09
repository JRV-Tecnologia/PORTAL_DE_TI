using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_PERFIL_USUARIO")]
    public class PerfilUsuarioDB
    {
        [Key]
        [Column("ID_PERFIL_USUARIO")]
        public Int32 IdPerfilUsuario { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }

        //foreingkey
       
        [Column("ID_USUARIO")]
        public Int32 UsuarioDBId { get; set; }
        public UsuarioDB UsuarioDB { get; set; }

        [Column("ID_PERFIL")]
        public Int32 PerfilDBId { get; set; }
        public PerfilDB PerfilDB { get; set; }

    }
}

