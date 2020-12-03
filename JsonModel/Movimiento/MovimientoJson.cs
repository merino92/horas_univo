using System;

namespace univo.JsonModel.MovimientoJson
{
    public class MovimientoJson
    {
        public int id {get;set;}
        public DateTime fecha {get;set;}
        public string documento {get;set;}
        public string usuario {get;set;}
        public string concepto {get;set;}
        public int entrada {get;set;}
        public int salida {get;set;}
        public int saldo {get;set;}
    }
}