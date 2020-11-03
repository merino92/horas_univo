
using System;
using System.Collections.Generic;
using System.Linq;
using univo.data;
using univo.Models;
﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.IO;

namespace univo.custom
{
    public class ProductosRepository
    {   
        private readonly univoContext context=null;
        private IWebHostEnvironment _env;
        public ProductosRepository(univoContext ct, IWebHostEnvironment en){
            context=ct;
            _env=en;
        } //constructor de la clase donde se instacion la bd.

        public List<Productos> listar(){
            return context.productos.Where(p=>p.borrado==false).ToList();
        }//retorna el listado de productos

        public Productos listbyid(int id){
            return context.productos.Find(id);
        }
        public List<Productos> Buscar(string codigo,string nombre){
            var productos=context.productos.Where(p=>p.codigo.Contains(codigo) || p.nombre.Contains(nombre)).ToList();
            return productos;
        }//retorna todas las coincidencias en la busqueda del producto 

        public int create(Productos producto,int idusuario){
           var existe=context.productos.Where(p=>p.codigo== producto.codigo || p.nombre== producto.nombre).Count();
           if(existe > 0){
               throw new Exception("El codigo Del Producto Ya Existe");
           }else{
                using var transaccion= context.Database.BeginTransaction();
               try{
                    var fecha= DateTime.Now;
                    var newproducto=producto;
                    newproducto.fecha=fecha;
                    context.Add(newproducto);
                    context.SaveChanges(); 
                    //agregamos el producto
                    var new_movimiento= new Movimientos{
                    fecha=fecha,
                    documento="",
                    idusuario=idusuario,
                    idproducto=newproducto.Id,
                    concepto="CREACION DEL PRODUCTO",
                    entrada=newproducto.existencia,
                    salida=0,
                    saldo=newproducto.existencia,
                    borrado=false
                };
                context.Add(new_movimiento);
                context.SaveChanges();
                //se crea el historial del producto en el movimiento
                transaccion.Commit();//finaliza transaccion se autoriza
                return newproducto.Id;

               }catch(Exception e){
                   throw new Exception(e.Message);
               }
           }

        }//crea el producto y retorna el id 

        public void update(Productos productos,int idusuario){
            var oldproducto=context.productos.Find(productos.Id);
            if(oldproducto!=null){
            
                var validacion=context.productos.Where(p=>(p.codigo==productos.codigo || p.nombre==productos.nombre)
                 && p.Id!=productos.Id).Count();
                 //valida que no exista un producto diferente con el mismo codigo o nombre 
                 if(validacion >0){
                    throw new Exception("No puedes actualizar ya existe un producto con codigo o nombre igual");
                 }else{
                    using(var transaccion=context.Database.BeginTransaction()){
                        int oldexistencia=oldproducto.existencia; //obtiene la existencia antes de update
                        oldproducto.codigo=productos.codigo;
                        oldproducto.nombre=productos.nombre;
                        oldproducto.marca=productos.marca;
                        oldproducto.existencia=productos.existencia;
                        oldproducto.detalle=productos.detalle;
                        oldproducto.imagen=productos.imagen;
                        context.SaveChanges();
                        //guardamos los cambios
                        if(oldproducto.existencia!=oldexistencia){
                            var new_movimiento= new Movimientos{
                                fecha=DateTime.Now,
                                documento="",
                                idusuario=idusuario,
                                idproducto=oldproducto.Id,
                                concepto="MODIFICACION DE EXISTENCIAS",
                                entrada=0,
                                salida=0,
                                saldo=oldproducto.existencia,
                                borrado=false
                            };
                            context.Add(new_movimiento);
                            context.SaveChanges();   
                        } //verifica si fue modificada la existencia   
                        transaccion.Commit();
                    }
                 }   
            }else{
                throw new Exception("Error al actualizar el producto no se encontro");
            }

        } //actualiza los datos del producto
   
        public int delete(int idproducto){
            var producto=context.productos.Find(idproducto);
            if(producto!=null){
                producto.borrado=true;
                context.SaveChanges();
                return producto.Id;
            }else{
                return 0;
            }
        } //borrado logico del producto

        /*private bool saveImage(string imagen, string nombre)
        {
            var ruta = _env.WebRootPath;
            var path = System.IO.Path.Combine(ruta, "pimagenes");
            if (!Directory.Exists(path))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
           
                string Base64String = imagen.Replace("data:image/png;base64,", "");

                byte[] bytes = Convert.FromBase64String(Base64String);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                }

                image.Save(path + ("/" + nombre)); //guarda la imagen en la carpeta
            return true;            

        } //convierte la imagen a archivo y la guarda*/

    }
}
