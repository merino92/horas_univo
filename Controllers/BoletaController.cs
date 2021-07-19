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

        [HttpPost]
        public IActionResult create(boletajson boleta){
            try
            {  
                //idusuario= (int)HttpContext.Session.GetInt32("idusuario");
                string cboleta= bo.create(boleta,1);
                if(cboleta.Length>0){
                    var item = new Dictionary<string,string>();
                    item.Add("key",cboleta);
                    return StatusCode(StatusCodes.Status201Created,item);
                }else{
                     var item = new Dictionary<string,string>();
                    item.Add("message","error al crear la boleta");
                    return StatusCode(StatusCodes.Status400BadRequest,item);
                }
            }
            catch (System.Exception e)
            {
                
                var item = new Dictionary<string,string>();
                    item.Add("message",e.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError,item);
            }
        }
        

    }
}
