using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace univo.Models
{
    public class Productos
    {
        
        public int Id { get; set; }
        [StringLength(25)] [Required]
        public string codigo { get; set; }
        [StringLength(75)]  [Required]
        public string nombre { get; set; }
        [StringLength(50)]
        public string marca { get; set; }
        [Required]
        public int existencia { get; set; }
        [Column(TypeName = "text")]
        public string detalle { get; set; }
        public string imagen { get; set; }
        [StringLength(50)]
        public string modelo {get;set;}
        public DateTime fecha { get; set; }
        [Required]
        public bool borrado { get; set; }

        public virtual ICollection<BoletasDetalles> boletasdetalles{get;set;}
        public virtual ICollection<Movimientos> movimientos{get;set;}

    }
}
