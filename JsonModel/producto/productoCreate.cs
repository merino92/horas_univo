
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace univo.JsonModel.producto
{
    public class productoCreate
    {
        public int id { get; set; }

        
        public string codigo { get; set; }
        public string nombre { get; set; }
        
        public string marca { get; set; }
        
        public int existencia { get; set; }
       
        public string detalle { get; set; }

        public string nombreimagen{get;set;}
        public string imagen{get;set;}

    }
}
