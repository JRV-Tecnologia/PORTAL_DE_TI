using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models
{
    [Table("TB_USUARIO")]
    public class UsuarioDB
    {
        [Key]
        [Column("ID_USUARIO")]
        public Int32 ID_USUARIO { get; set; }

        [Column("NOME")]
        public String NOME { get; set; }

        [Column("NOME_COMPLETO")]
        public String NOME_COMPLETO { get; set; }

        [Column("LOGIN")]
        public String LOGIN { get; set; }

        [Column("MATRICULA")]
        public String MATRICULA { get; set; }

        [Column("EMAIL")]
        public String EMAIL { get; set; }

        [Column("ID_PERFIL")]
        public Int32 ID_PERFIL { get; set; }

        [Column("DS_PERFIL")]
        public String DS_PERFIL { get; set; }
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}