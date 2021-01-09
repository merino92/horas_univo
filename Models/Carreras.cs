using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace univo.Models
{
    public class Carreras
    {
        [Key]
        public int id {get;set;}
        public int idfacultad {get;set;}
         [StringLength(100)][Required]
        public string carrerra {get;set;}
        public bool borrado {get;set;}

        [ForeignKey("idfacultad")]
        public virtual  Facultades facultades {get;set;}

        public virtual ICollection<Boletacarreras> boletacarreras {get;set;}
    }
}