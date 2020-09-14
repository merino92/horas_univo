using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace univo.Models
{
    public class Facultades
    {
        [Key]
        public int id{get;set;}
        [StringLength(50)][Required]
        public string nombre{get;set;}
        public bool borrado {get;set;}

        public virtual ICollection<Carreras> carreras {get;set;}
        public virtual ICollection<Boletas> boletas{get;set;}
    }
}