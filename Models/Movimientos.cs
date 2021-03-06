﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace univo.Models
{
    public class Movimientos
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        [StringLength(25)] [Required]
        public string documento { get; set; }
        [Required]
        
        public int idusuario { get; set; }
        [Required]
        public int idproducto {get; set;}

        [Required] [StringLength(250)]
        public string concepto{get;set;}
        [Required]
        public int entrada{get;set;}
        [Required]
        public int salida {get;set;}

        [Required]
        public int saldo {get;set;}

        public bool borrado{get;set;}
        [ForeignKey("idusuario")]
        public virtual Usuarios usuarios {get;set;}
        [ForeignKey("idproducto")]
        public virtual Productos productos{get;set;}
        public virtual ICollection<RequisicionDetalles> RequisicionDetalles { get; set; }
    }
}
