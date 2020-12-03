using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace univo.Models
{
    public class Requisiciones
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int idusuario { get; set; }
        [StringLength(25)]
        [Required]
        public string detalle { get; set; }
        [Required]
        public bool entrada { get; set; }

        public bool borrado { get; set; }
        [ForeignKey("idusuario")]
        public virtual Usuarios usuarios { get; set; }
    }
}
