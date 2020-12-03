using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using univo.data;
using univo.Models;

using univo.JsonModel.MovimientoJson;

namespace univo
{
    public class HistorialRepository
    {
        private readonly univoContext context=null;

        public HistorialRepository( univoContext ctx){
            context=ctx;
        } 

        public List<MovimientoJson> filtrarFecha(string fecha,int idproducto){
            var f=DateTime.Parse(fecha);
            var datos = context.movimientos.Include(u=>u.usuarios).
                        Where(m=>m.fecha.Date==f).ToList();
            List<MovimientoJson> mo = new List<MovimientoJson>();
            if(datos != null){
                foreach(Movimientos m in datos){
                    mo.Add(new MovimientoJson{
                        id=m.id,
                        fecha=m.fecha,
                        documento=m.documento,
                        usuario=m.usuarios.usuario,
                        concepto=m.concepto,
                        entrada=m.entrada,
                        salida=m.salida,
                        saldo=m.saldo
                    });
                }
            }            
            return mo;           
        }//retorna los movimientos de un producto en una fecha en especifico

        public List<MovimientoJson> filtrarRango(string fi,string ff, int idproducto){
                var fechai=DateTime.Parse(fi);
                var fechaf=DateTime.Parse(ff);
             var datos=context.movimientos.Include("usuarios").Where(m=>m.fecha.Date >= fechai &&
                                                m.fecha.Date <=fechaf 
                                                &&  m.idproducto== idproducto ).ToList();
            List<MovimientoJson> mo = new List<MovimientoJson>();
            if(datos != null){
                foreach(Movimientos m in datos){
                    mo.Add(new MovimientoJson{
                        id=m.id,
                        fecha=m.fecha,
                        documento=m.documento,
                        usuario=m.usuarios.usuario,
                        concepto=m.concepto,
                        entrada=m.entrada,
                        salida=m.salida,
                        saldo=m.saldo
                    });
                }
            }            
            return mo;      
        }//filtra los movimientos por reango de fechas

    }
}