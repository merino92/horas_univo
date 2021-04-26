using System;
using System.Linq;
using univo.data;
using univo.JsonModel.boleta;
using univo.Models;

namespace univo.custom
{
    public class BoletaRepository
    {
        private readonly univoContext context=null;
        public BoletaRepository(univoContext ct){
            context = ct;
        } 

        private string createCodigo(DateTime fecha,int boletaid,int idusuario){
            string format = fecha.ToString("yyyyMMddHHmmss");
            return (Convert.ToString(boletaid)+format);
        }//retorna el codigo autogenerado
        
        public int create(boletajson bo,int idusuario){
            try{
                DateTime fecha = DateTime.Now;
                using(var transaccion=context.Database.BeginTransaction()){
                    var boleta = new Boletas{
                        fecha= fecha,
                        codigo="",
                        idusuario=idusuario,
                        encargado=bo.encargado,
                        detalle=bo.detalle,
                        devuelto=false,
                        borrado=false,
                        parcial= false
                    };
                    context.boletas.Add(boleta);
                    context.SaveChanges();
                    //creamos la cabezera de la boleta
                    boleta.codigo = createCodigo(fecha, boleta.id, boleta.idusuario);
                    context.SaveChanges();
                    //agregamos el codigo de la boleta
                    foreach(int row in bo.carreras)
                    {
                        context.boletacarreras.Add(new Boletacarreras
                        {
                            idboleta=boleta.id,
                            idcarrera=row,
                            borrado=false
                        });
                        context.SaveChanges();
                    }
                    //agregamos la carreras de la boleta

                    foreach(int row in bo.materias)
                    {
                        context.boletamaterias.Add(new Boletamaterias
                        {
                            idboleta=boleta.id,
                            idmateria=row,
                            borrado=false
                        });
                        context.SaveChanges();
                    }
                    //agregamos las materias de la boletas

                    foreach (boletadetallejson row in bo.productos)
                    {
                        context.boletasdetalles.Add(new BoletasDetalles
                        {
                            iddetalle=boleta.id,
                            idproducto=row.idproducto,
                            cantidad=row.cantidad,
                            borrado=false
                        });
                        context.SaveChanges();
                        var producto = context.productos.Find(row.idproducto);
                        context.movimientos.Add(new Movimientos { 
                            fecha =boleta.fecha,
                            documento=boleta.codigo,
                            idusuario=boleta.idusuario,
                            idproducto=row.idproducto,
                            entrada=0,
                            salida=row.cantidad,
                            saldo=(producto.existencia-row.cantidad),
                            concepto="SALIDA POR ENTREGA DE PRODUCTO PARA USO DE LABORATORIO"

                        });
                        context.SaveChanges();
                        producto.existencia = (producto.existencia - row.cantidad);
                        context.SaveChanges();
                        //actualizamos el kardex
                    }//insertamos el detalle de la boleta
                    transaccion.Commit();
                    return boleta.id;
                }
            }catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public int delete(int idboleta)
        {
            try
            {

                using (var transaccion = context.Database.BeginTransaction()) {
                    var boleta = context.boletas.Find(idboleta);
                    if (boleta != null)
                    {
                        boleta.borrado = true;
                        var detalle = context.movimientos.Where(m => m.documento == boleta.codigo).ToList();
                        var fecha =  DateTime.Now;
                       foreach(Movimientos row in detalle)
                        {
                            var producto = context.productos.Find(row.idproducto);
                            int saldo =producto.existencia+ (row.entrada - row.salida);
                            producto.existencia = saldo;
                            context.movimientos.Add(new Movimientos { 
                                fecha=fecha,
                                idproducto=row.idproducto,
                                entrada=row.salida,
                                salida=row.entrada,
                                saldo=saldo,
                                borrado=false,
                                documento=row.documento,
                               concepto="POR ELIMINACION DE BOLETA"
                               
                            });
                        }
                        context.SaveChanges();
                        transaccion.Commit();
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }





                };


            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}