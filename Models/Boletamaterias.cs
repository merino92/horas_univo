using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace univo.Models
{
    public class Boletamaterias
    {
        [Key]
        public int id {get;set;}
        public int idboleta {get;set;}
        public int idmateria {get;set;}
        public bool borrado{get;set;}
        [ForeignKey("idboleta")]
        public virtual Boletas boletas {get;set;}
        [ForeignKey("idmateria")]
        public virtual Materias materias {get;set;}
        
    }
}