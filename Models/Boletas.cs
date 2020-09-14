using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace univo.Models
{
    public class Boletas
    {
        [Key]
        public int id{get;set;}
        [Required]
        public DateTime fecha{get;set;}
        [Required]
        public int idusuario{get;set;}
        [Required]
        public int idfacultad{get;set;}
        [Required]
        public int idcarrera{get;set;}
        [Required][StringLength(75)]
        public string encargado{get;set;}
        [Required][StringLength(250)]
        public string materia{get;set;}
        [Required][Column(TypeName = "text")]
        public string detalle{get;set;}
        [Required]
        public bool devuelto{get;set;}
        [Required]
        public bool borrado{get;set;}

        public virtual Facultades facultades{get;set;}
        public virtual Usuarios usuarios{get;set;}
        public virtual Carreras carreras{get;set;}
        public virtual ICollection<BoletasDetalles> boletadetalles{get;set;}

    }
}