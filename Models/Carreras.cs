using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public virtual  Facultades facultades {get;set;}

        public virtual ICollection<Boletas> boletas{get;set;}
        
    }
}