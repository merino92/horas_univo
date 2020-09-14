using System.ComponentModel.DataAnnotations;

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

        public virtual Boletas boletas{get;set;}
        public virtual Productos Productos{get;set;}
        
    }
}