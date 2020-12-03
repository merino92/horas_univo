using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace univo.Models
{
    public class RolesPermisos
    {
        
       public int id { get; set; }
     
        public int rolid { get; set; }
        public int moduloid { get; set; }
        public bool visualizar { get; set; }
        public bool crear { get; set; }
        public bool editar { get; set; }
        public bool borrar { get; set; }
        public bool imprimir { get; set; }

        [ForeignKey("rolid")]
        public virtual Roles rol { get; set; }
         [ForeignKey("idmodulo")]
        public virtual Modulos modulo { get; set; }


    }
}
