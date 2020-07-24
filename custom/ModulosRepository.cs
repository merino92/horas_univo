using univo.data;
using univo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using univo.JsonModel;
namespace univo.custom
{
    public class ModulosRepository
    {
        private readonly univoContext context =null;
        public ModulosRepository(univoContext contexto){
            context = contexto;
        }

        public List<Modulos> list(){
            var modulos = context.modulos.Where(e=>e.borrado == false ).ToList();
            return modulos;
        } //retorna todos los modulos del sistema
    }
}