using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace univo.Models
{
    public class Materias
    {
        [Key]
        public int id {get;set;}
        [StringLength(100)] [Required]
        public string materia {get;set;}

        public bool borrado {get;set;}
        public ICollection<Boletamaterias> boletamaterias {get;set;}
            
    }
}