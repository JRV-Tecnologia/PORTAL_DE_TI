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
        public Int32 Id { get; set; }

        [Column("NOME")]
        public String Nome { get; set; }

        [Column("NOME_COMPLETO")]
        public String NomeCompleto { get; set; }

        [Column("LOGIN")]
        public String Login { get; set; }

        [Column("MATRICULA")]
        public String Matricula { get; set; }

        [Column("EMAIL")]
        public String Email { get; set; }
   
        [Column("REMOVED")]
        public Boolean Removed { get; set; }
    }
}