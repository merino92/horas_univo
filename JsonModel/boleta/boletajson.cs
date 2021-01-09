using System.Collections.Generic;

namespace univo.JsonModel.boleta
{
    public class boletajson
    {   
        public int idboleta {get;set;}
        public string encargado{get;set;}
        public string detalle {get;set;}
        public List<int> materias {get;set;}
        public List<int> carreras {get;set;}
        public List<boletadetallejson> productos {get;set;}
    }
}