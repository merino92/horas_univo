using System;
using System.Collections.Generic;
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

        private string createCodigo(){
            string key="";
            int i=context.boletas.Count();
            while(true){
                i++;
                string codigo="BOL"+i.ToString();
                if(context.boletas.Where(b=>b.codigo==codigo).Count()<=0){
                    key=codigo;
                    break;
                }
            }
           return key;
        }//retorna el codigo autogenerado
         
        private  int validateExistencias (int idproducto,int cantidad){
            var item = context.productos.Find(idproducto);
            if(item!=null){
                int existencia = item.existencia;
                if(cantidad <=0){
                    cantidad =0;
                }
                int resultado = existencia - cantidad;
                if(resultado <0){
                    return -1;
                }else{
                    return 0;
                }
            }else{
                return -2;
            }
        }
        public Dictionary<string,string> create(boletajson bo,int idusuario){
            var response = new Dictionary<string,string>();
            try{
                DateTime fecha = DateTime.Now;
                using(var transaccion=context.Database.BeginTransaction()){
                    var boleta = new Boletas{
                        fecha= fecha,
                        codigo="",
                        idusuario=idusuario,
                        encargado=bo.encargado,
                        detalle="",
                        devuelto=false,
                        borrado=false,
                        parcial= false
                    };
                    context.boletas.Add(boleta);
                    context.SaveChanges();
                    //creamos la cabezera de la boleta
                    boleta.codigo = createCodigo();
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

                    foreach (boletadetallejson row in bo.detalle)
                    {   int validacion=validateExistencias(row.idproducto,row.cantidad);
                        if(validacion!=0){
                            if(validacion == -2){
                                throw new Exception("Error al obtener la existencia del producto");
                            }else{
                                var p = context.productos.Find(row.idproducto);
                                throw new Exception($"Existencias Insuficientes para el producto {p.nombre}");
                            }
                        }//valida si la existencia no queda en negativo

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
                    response.Add("validation","True");
                    response.Add("data",boleta.codigo);

                    return response;
                }
            }catch(Exception e){
                response.Add("validation","False");
                response.Add("data",e.Message);
                return response;
            }
        }

        public Dictionary<string,string> delete(int idboleta)
        {   var response = new Dictionary<string,string>();
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
                        response.Add("validate","True");
                        return response;
                    }
                    else
                    {
                       response.Add("validate","False");
                       response.Add("message","No se ha encontrado la boleta");
                       return response;
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