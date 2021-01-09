using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using univo.data;
using univo.JsonModel.mjson;
using univo.Models;

namespace univo.custom
{
    public class MovimientoRespository
    {
        private readonly univoContext context = null;
        public MovimientoRespository(univoContext ct){
            context=ct;
        }

        public List<Movimientosjs> listar(DateTime fecha, int idproducto){
           
            var movimientos=context.requisiciones.Include(u=>u.usuarios).
            Where(r=>r.fecha.Date==fecha && r.borrado==false).ToList();
            List<Movimientosjs> m = new List<Movimientosjs>();
            if(movimientos != null){
                foreach(Requisiciones r in movimientos){
                    m.Add(new Movimientosjs{
                        id=r.id,
                        fecha=r.fecha,
                        usuario=r.usuarios.usuario,
                        detalle=r.detalle,
                        entrada=r.entrada
                    });
                }
            }
            return m;
        } //obtiene los movimientos en una determinada fecha

        public List<Movimientosjs> FiltrarRango(DateTime fi,DateTime ff){
            List<Movimientosjs> m = new List<Movimientosjs>();
            var movimientos = context.requisiciones.Include(u=>u.usuarios).
            Where(r=>r.fecha.Date >=fi && r.fecha.Date <= ff).ToList();
            if(movimientos !=null){
                foreach(Requisiciones r in movimientos){
                     m.Add(new Movimientosjs{
                        id=r.id,
                        fecha=r.fecha,
                        usuario=r.usuarios.usuario,
                        detalle=r.detalle,
                        entrada=r.entrada
                    });
                }
            }
            return m;
        } //filtra por rango de fechas

        public MovimientoDetalle listId(int id){
            MovimientoDetalle movimiento= null;
            var requsicion=context.requisiciones.Include(u=>u.usuarios).
            Where(r=>r.id==id).Single();
            if(requsicion != null){
                movimiento.movimiento= new Movimientosjs{
                    id=requsicion.id,
                    fecha=requsicion.fecha,
                    usuario=requsicion.usuarios.usuario,
                    detalle=requsicion.detalle,
                    entrada=requsicion.entrada
                };
                var detalle = context.requisiciondetalles.Include(r=>r.producto).
                Where(r=>r.idrequisicion==id).ToList();
                foreach( RequisicionDetalles r in detalle){
                    movimiento.detalle.Add(new Detalle{
                        iddetalle=r.id,
                        codigo=r.producto.codigo,
                        producto=r.producto.detalle,
                        cantidad=r.cantidad,
                    });
                } 
                return movimiento;
            }else{  
                throw new Exception("Detalle no Encontrado");
            }

        } //retorna el detalle de la requisicion

        /*public int createEntrada(MovimientoAdd detalle,int idusuario){
            DateTime fecha= DateTime.Now;
            using(var transaccion = context.Database.BeginTransaction()){
                try
                {
                    var requisicion= new Requisiciones{
                        fecha=fecha,
                        idusuario=idusuario,
                        detalle=detalle.detalle,
                        entrada=detalle.entrada,
                        borrado=false
                    };
                    context.Add(requisicion);
                    context.SaveChanges();
                    //guarda la cabezera 
                    foreach(DetalleAdd d in detalle.productos){
                        if(d.cantidad >0){
                            context.Add(new RequisicionDetalles{
                                idproducto=d.idproducto,
                                cantidad=d.cantidad,
                                borrado=false
                            });
                            context.SaveChanges();
                            //inserta el producto
                            var producto = context.productos.Find(d.idproducto);
                            int existencia= producto.existencia;
                            if(detalle.entrada){
                                existencia=producto.existencia+d.cantidad;
                            }else{

                            }
                        }
                    }

                    
                }
                catch (Exception e)
                {
                    
                    throw;
                }
            }
        }//crea la requisicion*/


    }
}