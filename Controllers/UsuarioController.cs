using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using univo.custom;
using univo.JsonModel;
using univo.JsonModel.usuario;
using univo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace univo.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: /<controller>/
        private readonly UsuarioRepository user = null;
        private readonly RolesController rol =null;
        public UsuarioController(UsuarioRepository us,RolesController rols){
            user=us;
            rol=rols;
        }//instancio la clase en el constructor
        public IActionResult Index()
        {   
            
                return View();
        } 

        [HttpGet]
        public JsonResult list(){
            
            return Json(new usuarios{ request=0,response=user.listar()});
        } //obtiene todos los usaurios no borrados

        [HttpGet]
        public JsonResult listid([FromQuery(Name = "id")] int id){
            return Json(new usuario{
                request=0,
                response=user.listarid(id)
            });
        } //obtiene el usuario especifico

        [HttpPost]
        public JsonResult create([FromBody] Usuarios newuser ){
            if(ModelState.IsValid){
                int res = user.create(newuser);
                if(res<0){
                    return Json(new error{request=1,response="El usuario ya ha sido asignado"});
                }else if(res == 0){
                     return Json(new error{request=1,response="Algo ocurrio no se pudo crear"});
                }else{
                     return Json(new error{request=0,response="Usuario Creado"});
                }
            }else{
                return Json(new error{request=1,response="Datos no Validos"});
            }
        } //funcion que crea el usuario

        [HttpPut]
        public JsonResult update([FromBody] Usuarios upuser){
            if(ModelState.IsValid){
                int res = user.update(upuser);
                if(res < 0){
                    return Json(new error{request=1,response="El usuario ya ha sido asignado"});
                }else if(res ==0){
                    return Json(new error{request=0,response="Usuario Actualizado"});
                }else{
                    return Json(new error{request=1,response="El usuario no existe"});
                }
            }else{
                return Json(new error{request=1,response="Datos no Validos"});
            } //valida que los datos sean correctos

        }//actualiza los datos del usuario

        [HttpDelete]
        public JsonResult delete([FromQuery(Name = "id")] int id){
            int res =user.delete(id);
            if(res > 0){
                return Json(new error{request=1,response="El usuario no existe"});
            }else{
                return Json(new error{request=0,response="Usuario Eliminado"});
            }
        }//borrado logico del usuario
    }
}
