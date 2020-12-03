using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace univo.Models
{
    public class RequisicionDetalles
    {
       public int id { get; set; }
       [Required]
       public int idproducto { get; set; }
       [Required]
        public int idrequisicion{get;set;}
       public int cantidad { get; set; }
        public bool borrado { get; set; }
        [ForeignKey("idproducto")]
        public virtual Productos producto { get; set; }
        [ForeignKey("idrequsicion")]
        public virtual Requisiciones requisicion {get;set;}
    }
}
