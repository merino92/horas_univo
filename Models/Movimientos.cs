using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(50)] [Required]
        public string usuario { get; set; }


    }
}
