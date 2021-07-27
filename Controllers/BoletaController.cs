using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using univo.custom;
using univo.data;
using univo.JsonModel.boleta;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace univo.Controllers
{
    public class BoletaController : Controller
    {   
        private readonly univoContext context=null;
        private readonly BoletaRepository bo;
        public BoletaController(univoContext ct,BoletaRepository b){
            context = ct;
            bo = b;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        } 

       

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

        [HttpPost]
        public IActionResult create([FromBody]boletajson boleta){
            var item = new Dictionary<string,string>();
            try
            {  
                if(boleta.carreras.Count()>0 && boleta.materias.Count()>0 
                    && boleta.facultad.Count()>0 && boleta.detalle.Count()>0
                    && boleta.encargado.Length > 0){
                    var cboleta = bo.create(boleta,1);
                    if(Convert.ToBoolean(cboleta["validation"])){
                        item.Add("key",cboleta["data"]);
                        return StatusCode(StatusCodes.Status201Created,item);
                    }else{
                        item.Add("message",cboleta["data"]);
                        return StatusCode(StatusCodes.Status400BadRequest,item);
                    }
                }else{
                    
                    item.Add("message","Parametros invalidos");
                    return StatusCode(StatusCodes.Status400BadRequest,item);
                }
                //idusuario= (int)HttpContext.Session.GetInt32("idusuario");
               
            }
            catch (System.Exception e)
            {
                    item.Add("message",e.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError,item);
            }
        }
        
        [HttpDelete]
        public IActionResult delete([FromQuery(Name="idboleta")]int idboleta){
            var request = new Dictionary<string,string>();
            try
            {
                if(idboleta>0){
                    var respuesta = bo.delete(idboleta);
                    if(Convert.ToBoolean(respuesta["validate"])){
                        return StatusCode(StatusCodes.Status200OK); 
                    }else{
                        return StatusCode(StatusCodes.Status400BadRequest,Json(respuesta["message"]));
                    }
                }else{
                    request.Add("message","Parametro Invalido");
                    return StatusCode(StatusCodes.Status400BadRequest,Json(request));
                }
            }
            catch (Exception e)
            {
                request.Add("message",e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,request);
                
            }
            
        }

    }
}
