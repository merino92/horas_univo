using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using univo.custom;
using univo.JsonModel;
using univo.JsonModel.producto;
using univo.Models;

namespace univo.Controllers
{
    public class ProductoController : Controller
    {   
        private readonly ProductosRepository pr=null;

        public ProductoController(ProductosRepository p){
            pr=p;
        }
        public IActionResult Index()
        {   
            
            return View();
        }

        [HttpPost]
        public IActionResult create([FromBody] productoCreate producto ){
            try{
                if(ModelState.IsValid){
                    int idusuario=0;
                    idusuario= (int)HttpContext.Session.GetInt32("idusuario");
                    if(idusuario>0){
                        var newproducto= new Productos{
                            codigo=producto.codigo,
                            marca=producto.marca,
                            nombre=producto.nombre,
                            existencia=producto.existencia,
                            detalle=producto.detalle,
                            modelo=producto.modelo,
                            imagen=producto.imagen,
                            fecha=DateTime.Now,
                            borrado=false

                        };
                         var respuesta=pr.create(newproducto,idusuario);
                         if (respuesta >0){
                             return StatusCode(StatusCodes.Status201Created,Json(new error{request=respuesta,response="Producto creado"}));
                         }else{
                              return StatusCode(StatusCodes.Status200OK,Json(new error{request=0,response="No se pudo crear"}));
                         }
                    }else{
                        return StatusCode(StatusCodes.Status401Unauthorized,Json(new error{request=403,response="usuario invalido"}));
                    }
                   
                }else{
                    return StatusCode(StatusCodes.Status400BadRequest,Json(new error{request=0,response="No se recibieron parametros"}));
                }

            }catch(Exception e){
                return StatusCode(StatusCodes.Status500InternalServerError,Json(new error{request=0,response=e.Message}));
            }
        }//crea el producto 

        [HttpGet]
        public IActionResult list(){
            var productos=pr.listar();
            return StatusCode(StatusCodes.Status200OK,Json(productos));
        } 

        [HttpGet]
        public IActionResult listbyid([FromQuery(Name="id")] int id){
             if(id>0){
                 return StatusCode(StatusCodes.Status200OK,Json(pr.listbyid(id)));
             }else{
                 return StatusCode(StatusCodes.Status406NotAcceptable,
                 Json(new error{request=1,response="No se encontro el producto"}));
             }
        }

        [HttpDelete]
        public IActionResult delete([FromQuery(Name = "id")] int id){
            if(id > 0){
                int respuesta=pr.delete(id);
                if(respuesta>0){
                    return StatusCode(StatusCodes.Status200OK,Json(new error{
                        request=0,
                        response="Producto Eliminado"
                    }));
                }else{
                    return StatusCode(StatusCodes.Status400BadRequest,Json(new error{
                        request=1,
                        response="Error al Intentar Eliminar el Producto"
                    }));
                }
            }else{
                return StatusCode(StatusCodes.Status400BadRequest,Json(new error{
                    request=1,response="Identificador No valido"
                }));
            }
        } //borrado logico del producto

        [HttpPut]
        public IActionResult update([FromBody] productoCreate producto){
            if(ModelState.IsValid){
                int idusuario=0;
                idusuario= (int)HttpContext.Session.GetInt32("idusuario");
                if(idusuario >0){
                    var p= new Productos{
                            Id=producto.id,
                            nombre=producto.nombre,
                            codigo=producto.codigo,
                            marca=producto.marca,
                            existencia=producto.existencia,
                            imagen="",
                            detalle=producto.detalle
                    };
                    try{
                        pr.update(p,idusuario);
                        return StatusCode(StatusCodes.Status200OK,Json(new error{request=0,response="Producto Actualizado"}));
                    }catch(Exception e){
                        return StatusCode(StatusCodes.Status500InternalServerError,Json(
                            new error{request=1,response=e.Message}
                        ));
                    }
                }else{
                    return StatusCode(StatusCodes.Status401Unauthorized,
                        Json(new error{request=1,response="Usuario no valido"}));
                }
            }else{
                return StatusCode(StatusCodes.Status406NotAcceptable,
                Json(new error{ request=1,response="Parametros no valido"}));
            }
        }
    }
}
