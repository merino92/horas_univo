using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using univo.data;
using univo.Models;

namespace univo.Controllers
{
    public class MateriaController:Controller
    {   
        private readonly univoContext context=null;

        public MateriaController(univoContext ct){
            context=ct;
        }
        public IActionResult Index(){
            return View();
        } 
        [HttpGet]
        public IActionResult list(){
            var materias = context.materias.Where(m=>m.borrado==false).ToList();
            return StatusCode(StatusCodes.Status200OK,Json(materias));
        }//lista todo los  

        [HttpGet]
        public IActionResult getId([FromQuery(Name="id")] int id){
            var materia =context.materias.Find(id);
            if(materia !=null){
                return StatusCode(StatusCodes.Status200OK,Json(materia));
            }else{
                var mensaje = new Dictionary<string,string>();
                mensaje.Add("mensaje","materia no encontrada");
                return StatusCode(StatusCodes.Status404NotFound,Json(mensaje));
            }
            
        }//obtiene por id 

        [HttpGet]
        public IActionResult search([FromQuery(Name="busqueda")] string busqueda ){
            if(busqueda.Length >0){
                var materias =context.materias.Where(m=>m.materia.Contains(busqueda) && m.borrado==false).ToList();
                return StatusCode(StatusCodes.Status200OK,Json(materias));
            }else{
                var mensaje = new Dictionary<string,string>();
                mensaje.Add("mensaje","parametros invalidos");
                return StatusCode(StatusCodes.Status400BadRequest,Json(mensaje));
            }
        }

        [HttpPost]
        public IActionResult create([FromBody] Materias materia){
            try
            { 
                var error = new Dictionary<string,string>();
                if(materia.materia.Length>0){
                     context.Add(materia);
                     context.SaveChanges();
                     error.Add("mensaje","Creado");
                     return StatusCode(StatusCodes.Status201Created,Json(error));   
                }else{
                    error.Add("mensaje","Datos no validos");
                    return StatusCode(StatusCodes.Status400BadRequest,Json(error));
                }
            }
            catch (Exception e)
            {   var error = new Dictionary<string,string>();
                error.Add("mensaje",e.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError,
                    Json(error));
            }
        }//crea la materia 


        [HttpPut]
        public IActionResult update([FromBody] Materias materia){
            try
            {
                if(materia.id >0 && materia.materia.Length>0){
                    var mat= context.materias.Find(materia.id);
                    var mensaje = new Dictionary<string,string>();
                    if(mat !=null){
                        mat.materia=materia.materia;
                        context.SaveChanges();
                        mensaje.Add("mensaje","materia actualizada");
                        return StatusCode(StatusCodes.Status200OK,Json(mensaje));
                    }else{
                        mensaje.Add("mensaje","materia no encontrada");
                        return StatusCode(StatusCodes.Status404NotFound,Json(mensaje));
                    }

                }else{
                    var error = new Dictionary<string,string>();
                    error.Add("mensaje","parametros invalidos");
                    return StatusCode(StatusCodes.Status400BadRequest,Json(error));
                }

            }
            catch (Exception e)
            {
                var error = new Dictionary<string,string>();
                error.Add("mensaje",e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,Json(error));
                
            }
        }
    

        [HttpDelete]
        public IActionResult delete([FromQuery(Name="id")] int id){
            if(id>0){
                var materia = context.materias.Find(id);
                var mensaje = new Dictionary<string,string>();
                if(materia!=null){
                    materia.borrado=true;
                    context.SaveChanges();
                    mensaje.Add("mensaje","materia eliminada");
                    return StatusCode(StatusCodes.Status200OK,Json(mensaje));
                }else{
                    mensaje.Add("mensaje","error al eliminar materia");
                    return StatusCode(StatusCodes.Status400BadRequest,Json(mensaje));
                }
            }else{
                var mensaje = new Dictionary<string,string>();
                mensaje.Add("mensaje","parametro invalido");
                return StatusCode(StatusCodes.Status400BadRequest,Json(mensaje));
            }
        }
    }
}