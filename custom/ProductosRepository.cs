using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using univo.data;
using univo.JsonModel.producto;
using univo.Models;


namespace univo.custom
{
    public class ProductosRepository
    {
        private readonly univoContext context = null;
        private IHostingEnvironment _env;
        public ProductosRepository(univoContext ctx, IHostingEnvironment env)
        {
            context = ctx;
            _env = env;
        }

        public List<Productos> listar()
        {
            var productos = context.productos.Where(p => p.borrado == false).ToList();
            return productos;
        }

        private bool saveImage(string imagen, string nombre)
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

        } //convierte la imagen a archivo y la guarda

        public int create(productoCreate producto)
        {
            using(var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    DateTime fecha = DateTime.Now;
                    var data = new Productos
                    {
                        codigo = producto.codigo,
                        nombre = producto.nombre,
                        marca = producto.marca,
                        existencia = producto.existencia,
                        detalle = producto.detalle,
                        fecha = fecha,
                        borrado = false
                    };
                    context.Add(data);
                    context.SaveChanges();

                    if(producto.nombreImagen != null)
                    {
                        string nimagen = data.Id + producto.nombreImagen+fecha; //asignamos el id y la fecha
                        bool res = this.saveImage(producto.imagen, nimagen);

                    }
                    transaction.Commit();
                    return data.Id;
                }catch(Exception e)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
            
        } //crea el producto en el inventario
    }
}
