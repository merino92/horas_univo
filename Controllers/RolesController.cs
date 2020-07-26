using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using univo.custom;
using univo.JsonModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace univo.Controllers
{
    public class RolesController : Controller
    {   

        private readonly Rolesrepository roles = null; //objecto de la clase repository
        private readonly ModulosRepository modulo = null;
        private readonly int n_modulo=1;
        private readonly permisos  permisos = new permisos();
        private readonly UsuarioRepository user = null;
        public RolesController(Rolesrepository rol ,ModulosRepository mo,UsuarioRepository us){
            roles = rol;
            modulo= mo;
         
            user =us;
        }//asignamos las instancia
        
        // GET: /<controller>/
        public IActionResult Index()
        {   
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario"))){
                return RedirectToAction("Index","Login");
            }else{
                var rol = HttpContext.Session.GetInt32("idrol");
                
                if(user.validatePermiss(n_modulo, (int)rol,permisos.visualizar())){
                    return View();
                }else{
                    return RedirectToAction("Index","Home");
                }   
                
            }//valida que exista cesion y que tenga permiso
        
            
        }

        [HttpGet]
        public JsonResult list(){
           var datos = roles.listar();
           var res = new rol{
               request = 0,
               roles = datos
           }; 
           return Json(res);
        } //lista todo los roles disponibles

        [HttpGet]
        public JsonResult ListId([FromQuery(Name = "id")] int id){
            var rol = roles.listarId(id);
            var res = new rolPermiso{
                request =0,
                permisos = rol
            };

            return Json(res);
        } //lista los permisos por id del rol

        [HttpPost]
        public JsonResult create([FromBody] rolCreate data ){
            if(ModelState.IsValid){
                try
                {
                    int res = roles.crearRolPermiso(data.nombre,data.permisos); //crea el rol y los permisos
                    return Json(new error{request=0,response="Rol Creado Exitosamente"}); //retorna la respuesta
                }
                catch (Exception e)
                {
                    return Json(new error{request=1,response=e.Message}); //retorna el error
                }
            }else{
               return Json(new error{ request=1,response="Datos no validos"});
            } //valida que los datos sean validos
        }//crea el rol y los permisos

        [HttpPut]
        public JsonResult update([FromBody] rolUpdate data){
            if(ModelState.IsValid){
                try
                {
                    int res = roles.updateRolPermisos(data);
                    return Json(new error{request=0,response="Rol Creado Exitosamente"}); //retorna la respuesta
                }
                catch (Exception e)
                {
                    return Json(new error{request=1,response=e.Message}); //retorna el error
                }
            }else{
                 return Json(new error{ request=1,response="Datos no validos"});
            }
        } //actualiza el nombre y los permisos del rol

        [HttpDelete]
        public JsonResult delete([FromQuery(Name = "id")] int id){
            if (id > 0){
                int res = roles.borrar(id);
                if(res > 0){
                    return Json(new error{request=1,response="El rol que intentas eliminar no existe"}); //retorna el error
                }else{
                     return Json(new error{request=0,response="Rol Eliminado Exitosamente"}); //retorna la respuesta
                }
            }else{
                return Json(new error{ request=1,response="Datos no validos"});
            }
        }//borrado logico del rol

        [HttpGet]
        public JsonResult listModulos(){
            var modulos = modulo.list();
            return Json(modulos);
        }//lista los modulos
    }
}
