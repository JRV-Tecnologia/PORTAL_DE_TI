using PORTAL_DE_TI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Models

{
    [Table("TB_USUARIO_ACAO")]
    public class UsuarioAcaoDB
    {
        //properties
        [Key]
        [Column("ID_USUARIO_ACAO")]
        public Int32 IdPerfilAcao { get; set; }        
                
        [Column("REMOVED")]
        public Boolean Removed { get; set; }

        //foreingkey
        [Column("ID_MENU")]
        public Int32 MenuDBId { get; set; }
        public MenuDB MenuDB { get; set; }
                
        [Column("ID_ACAO")]
        //public Int32 AcaoDBAcaoId { get; set; }
        public Int32 AcaoDBId { get; set; }
        public AcaoDB AcaoDB { get; set; }

        [Column("ID_USUARIO")]
        //public Int32 AcaoDBAcaoId { get; set; }
        public Int32 UsuarioDBId { get; set; }
        public UsuarioDB UsuarioDB { get; set; }

    }
}
