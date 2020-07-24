using System.Collections.Generic;
using univo.Models;

namespace univo.JsonModel
{
    public class rolUpdate
    {
        public int rolid {get;set;}
        public string nombre {get;set;}
        public List<RolesPermisos> permisos {get;set;}
    }
}