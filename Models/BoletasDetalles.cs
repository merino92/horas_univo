using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace univo.Models
{
    public class BoletasDetalles
    {
        [Key]
        public int id{get;set;}
        [Required]
        public int iddetalle{get;set;}
        [Required]
        public int idproducto{get;set;}
        [Required]
        public int cantidad{get;set;}
        public bool borrado{get;set;}
        [ForeignKey("iddetalle")]
        public virtual Boletas boletas{get;set;}
         [ForeignKey("idproducto")]
        public virtual Productos Productos{get;set;}
        
    }
}