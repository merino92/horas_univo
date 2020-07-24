using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace univo.Models
{
    public class Usuarios
    {
        public int id { get; set; }
       [StringLength(50)][Required]
        public string nombres { get; set; }
        [StringLength(50)][Required]
        public string apellidos { get; set; }
        [StringLength(50)] [Required]
        public string usuario { get; set; }
        [Column(TypeName = "text")] [Required]
        public string clave { get; set; }
        public int rolid { get; set; }
        public bool borrado {get;set;}

        public virtual Roles rol { get; set; }
    }
}
