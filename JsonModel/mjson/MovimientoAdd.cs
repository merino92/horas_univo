using System.Collections.Generic;

namespace univo.JsonModel.mjson
{
    public class MovimientoAdd
    {
        public string detalle {get;set;}
        public bool entrada{get;set;}
        public List<DetalleAdd> productos {get;set;}
    }
}