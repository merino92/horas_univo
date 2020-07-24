using System.Collections.Generic;
using univo.Models;

namespace univo.JsonModel
{
    public class rolPermiso
    {
        public int request {get;set;}
        public List<RolesPermisos> permisos {get;set;}
    }
}