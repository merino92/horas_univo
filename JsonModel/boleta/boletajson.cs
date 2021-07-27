using System.Collections.Generic;

namespace univo.JsonModel.boleta
{
    public class boletajson
    {   
       
        public string encargado{get;set;}
        //public string comentario {get;set;}
        public List<int> materias {get;set;}
        public List<int> carreras {get;set;}
        public List<int> facultad {get;set;}
        public List<boletadetallejson> detalle {get;set;} 
        
    }
}