using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace univo.Models
{
    public class Modulos
    {
        public int id { get; set; }
        [StringLength(50)][Required]
        public string modulo { get; set; }
        [Required]
        public bool borrado { get; set; }

        public virtual ICollection<RolesPermisos> rolespermisos { get; set; }
    }
}
