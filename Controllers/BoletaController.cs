using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using univo.data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace univo.Controllers
{
    public class BoletaController : Controller
    {   
        private readonly univoContext context=null;

        public BoletaController(univoContext ct){
            context=ct;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        } 

        private string generateCode(){
            string key="";
            int i=context.boletas.Count();
            while(true){
                i++;
                string codigo="BOL"+i.ToString();
                if(context.boletas.Where(b=>b.codigo==codigo).Count()<=0){
                    key=codigo;
                    break;
                }
            }
           return key;

        }//generacion de codigo automatico

        [HttpGet]
        public IActionResult list(){
            var boletas = context.boletas.Where(b=>b.borrado==false).ToList();
            return StatusCode(StatusCodes.Status200OK,Json(boletas)); 
        } //lista las boletas

        [HttpGet]
        public IActionResult listId([FromQuery(Name="id")]int id){
            if(id>0){
                var boleta = context.boletas.Find(id);
                if(boleta!=null){
                    return StatusCode(StatusCodes.Status200OK,Json(boleta));
                }else{
                    var mensaje=new Dictionary<string,string>();
                    mensaje.Add("mensaje","Boleta no Encotrada");
                    return StatusCode(StatusCodes.Status404NotFound,Json(mensaje));
                }
            }else{
                var mensaje=new Dictionary<string,string>();
                mensaje.Add("mensaje","Paramatros Invalidos");
                return StatusCode(StatusCodes.Status400BadRequest,Json(mensaje));
            }
        }//lista la boleta por id

        [HttpGet]
        public IActionResult searchCodigo([FromQuery(Name="codigo")]string codigo){
            if(codigo.Length>0){
                var boletas = context.boletas.Where(b=>b.codigo.Contains(codigo)).ToList();
                return StatusCode(StatusCodes.Status200OK,Json(boletas));
            }else{
                var mensaje=new Dictionary<string,string>();
                mensaje.Add("mensaje","Parametros Invalidos");
                return StatusCode(StatusCodes.Status400BadRequest,Json(mensaje));

            }
        }//busca por codigo 

        [HttpGet]
        public IActionResult listarFacultades()
        {
            var falcutades = context.facultades.Where(f => f.borrado == false).ToList();
            return StatusCode(StatusCodes.Status200OK, Json(falcutades));
        }

        [HttpGet]
        public IActionResult listarCarreras()
        {
            var carreras = context.carreras.Where(c => c.borrado == false).ToList();
            return StatusCode(StatusCodes.Status200OK, Json(carreras));
        }

        

    }
}
