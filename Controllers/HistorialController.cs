using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using univo.JsonModel.MovimientoJson;
using univo.custom;
using univo.JsonModel;
using univo.Models;
using System;

namespace univo.Controllers
{
    public class HistorialController:Controller
    {   
        private readonly HistorialRepository historial=null;
        public HistorialController(HistorialRepository hr){
            historial=hr;
        }
        public IActionResult Index()
        {   
            
            return View();
        }

        [HttpGet]
        public IActionResult search([FromQuery(Name="id")] int id,[FromQuery(Name="fi")] string fi,
                                    [FromQuery(Name="ff")] string ff,[FromQuery(Name="caso")] int caso){
                if(id >0 && caso >0 && fi.Length > 0 && ff.Length >0){
                    List<MovimientoJson> datos=null;
                    try{
                        switch(caso){
                            case 1:
                                datos=historial.filtrarFecha(fi,id);
                            break;
                            default:
                                datos=historial.filtrarRango(fi,ff,id);
                            break;
                        };
                        return StatusCode(StatusCodes.Status202Accepted,Json(datos));
                    }catch(Exception e){
                        return StatusCode(StatusCodes.Status500InternalServerError,Json(new error{
                            request=1,
                            response=e.Message
                        }));
                    }
                }else{
                    return StatusCode(StatusCodes.Status400BadRequest,Json(new error{request=1,
                    response="Parametros no validos"}));
                }                        
            
        }//filtra los movimientos en base al id y las fechas
    }
}