using System;
using System.ComponentModel.DataAnnotations;

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


        public virtual Roles rol { get; set; }
        public virtual Modulos modulo { get; set; }


    }
}
