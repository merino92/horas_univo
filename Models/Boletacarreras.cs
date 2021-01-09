using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace univo.Models
{
    public class Boletacarreras
    {
        [Key]
        public int id {get;set;}
        public int idboleta {get;set;}
        public int idcarrera{get;set;}
        public bool borrado{get;set;}
        [ForeignKey("idcarrera")]
        public virtual Carreras carreras{get;set;}
        [ForeignKey("idboleta")]
        public virtual  Boletas boletas{get;set;}
        
    }
}