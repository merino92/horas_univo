﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace univo.Models
{
    public class Usuarios
    {
        public int id { get; set; }
       [StringLength(50)][Required]
        public string nombres { get; set; }
        [StringLength(50)][Required]
        public string apellidos { get; set; }
        [StringLength(50)] [Required]
        public string usuario { get; set; }
        
        [Required]
        public string clave { get; set; }
        public int rolid { get; set; }
        public bool borrado {get;set;}

        [ForeignKey("rolid")]
        public virtual Roles rol { get; set; }

        public virtual ICollection<Movimientos> movimientos{get;set;}
        public virtual ICollection<Boletas> boletas{get;set;}
    }
}
