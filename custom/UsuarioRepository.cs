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
            if(context.usuarios.Where(u => u.usuario == data.usuario && u.id != data.id ).Count()>0){
                return -1;
            }else{
                var usuario = context.usuarios.Find(data.id);
                if(usuario !=null){
                    usuario.nombres =data.nombres;
                    usuario.apellidos= data.apellidos;
                    usuario.usuario = data.usuario;
                    if(usuario.clave != data.clave){
                        usuario.clave = pass.Encrypt(data.clave);
                    } //valida si se ha cambiado la clave 
                    usuario.rolid = data.rolid;
                    usuario.borrado = false;
                    context.SaveChanges();
                    res =0;
                }//existe el usuario a actualizar
            }
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

        public Usuarios  ValidateLogin(string user,string password){
           
            var res = context.usuarios.Where(u => u.usuario == user && u.borrado == false).SingleOrDefault();
            if(res !=null){
                if(password == pass.Decrypt(res.clave)){
                    return res;
                }else{
                   return res;
                }
            }else{
                return res;
            }
        }//valida las credenciales del usuario

        public bool validatePermiss(int modulo,int rol,int permiso){
            var permisos = context.roles_permisos.Where(rm =>rm.moduloid==modulo && rm.rolid == rol).Single();
            if(permisos !=null){
                bool res = false;
                switch(permiso){
                    case 0:
                        res =permisos.visualizar;
                    break;
                    case 1:
                        res =permisos.crear;
                    break;
                    case 2:
                        res = permisos.editar;
                    break;
                    case 3:
                        res = permisos.borrar;
                    break;
                    default:
                        res =permisos.imprimir;
                    break;                    

                }
                return res;
            }else{
                return false;
            }

        }
    }
}