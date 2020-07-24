using System.Collections.Generic;
using univo.data;
using univo.Models;
using System.Linq;
namespace univo.custom
{
    public class UsuarioRepository
    {
        private readonly univoContext context = null;
        private readonly encrypt pass = null;
        public UsuarioRepository(univoContext ct,encrypt pas){
            context = ct;
            pass =pas;
        }
        public List<Usuarios> listar(){
            var usuarios = context.usuarios.Where(u => u.borrado == false ).ToList();
            return usuarios;
        }//lista los usuarios 

        public Usuarios listarid(int id){
            var user = context.usuarios.Find(id);
            return user;
        }//busca por id

        public int create(Usuarios data){
            if(context.usuarios.Where(u => u.usuario == data.usuario).Count() > 0){
                return -1; //revisa si ya existe el nombre de usuario
            }else{
            Usuarios newuser= new Usuarios{
                nombres=data.nombres,
                apellidos=data.apellidos,
                usuario = data.usuario,
                clave = pass.Encrypt(data.clave),
                rolid = data.rolid,
                borrado = false
            };
            context.usuarios.Add(newuser);
            context.SaveChanges();
            return newuser.id;
            }
        }//crea el usuario

        public int update(Usuarios data){
            int res =1;
            var usuario = context.usuarios.Find(data.id);
            if(usuario !=null){
                usuario.nombres =data.nombres;
                usuario.apellidos= data.apellidos;
                usuario.usuario = data.usuario;
                usuario.clave = pass.Encrypt(data.clave);
                usuario.rolid = data.rolid;
                usuario.borrado = false;
                context.SaveChanges();
                res =0;
            }//existe el usuario a actualizar
            return res;
        }//actualiza los datos del empleado 

        public int delete(int id){
            int res =1;
            var user = context.usuarios.Find(id);
            if(user !=null){
                user.borrado = true;
                context.SaveChanges();
                res =0;
            }
            return res;
        } //borrado logico

        
    }
}