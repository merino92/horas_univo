using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using univo.custom;
using univo.JsonModel.usuario;
using univo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace univo.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        private readonly UsuarioRepository user = null;

        public LoginController(UsuarioRepository us){
            user = us;
        }
        public IActionResult Index()
        {   HttpContext.Session.Clear(); //destruye la sesion
            return View();
        }

        [HttpPost]
        public IActionResult validar(string usuario,string clave){
            if(usuario !=null && clave !=null){
               Usuarios res = user.ValidateLogin(usuario.ToUpper(),clave);
                if(res !=null){
                    HttpContext.Session.SetString("usuario",usuario.ToUpper());
                    HttpContext.Session.SetInt32("idrol",res.rolid);
                    HttpContext.Session.SetInt32("idusuario",res.id);
                    //crea la sesion del usuario
                    return RedirectToAction("Index","Home");
                }else{
                    ViewBag.error = "Usuario o Clave Invalidos";
                    return View("Index");
                }
            }else{
                ViewBag.error = "Usuario o Clave Vacios";
                return View("Index");
            }
        } //valida el login
    }
}
