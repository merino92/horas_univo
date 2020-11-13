using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using univo.data;
using univo.Models;

namespace univo
{
    public class HistorialRepository
    {
        private readonly univoContext context=null;

        public HistorialRepository( univoContext ctx){
            context=ctx;
        } 

        public List<Movimientos> filtrarFecha(string fecha,int idproducto){
            var f=DateTime.Parse(fecha);
            var datos=context.movimientos.Where(m=>m.fecha.Date == f.Date &&
                                                m.idproducto== idproducto ).ToList();
            return datos;
        }//retorna los movimientos de un producto en una fecha en especifico

        public List<Movimientos> filtrarRango(string fi,string ff, int idproducto){
                var fechai=DateTime.Parse(fi);
                var fechaf=DateTime.Parse(ff);
             var datos=context.movimientos.Where(m=>m.fecha.Date >= fechai &&
                                                m.fecha.Date <=fechaf 
                                                &&  m.idproducto== idproducto ).ToList();
            return datos;
        }//filtra los movimientos por reango de fechas

    }
}