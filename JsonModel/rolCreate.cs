using System.Collections.Generic;
using univo.Models;

namespace univo.JsonModel
{
    public class rolCreate
    {
        public string nombre {get;set;}
        public List<RolesPermisos> permisos{get;set;}
    }
}