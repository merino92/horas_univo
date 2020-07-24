using univo.data;
using univo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using univo.JsonModel;

namespace univo{

    
    public class Rolesrepository{
        private readonly univoContext context =null;
        public Rolesrepository(univoContext contexto){
            context=contexto;

        }//obtiene el contexto para hacer las transacciones en la bd

        public List<Roles> listar(){
            var roles= context.roles.Where(e=> e.borrado==false).ToList();
            return roles;
        }//lista los roles que existen y que no han sido borrados
        
        public List<RolesPermisos> listarId(int id){
            return context.roles_permisos.Where(e=> e.rolid == id).ToList();
        }
        public List<RolesPermisos> listarPermisos(int id){
           // var rol = context.roles_permisos.Where(e => e.rol.id==id).ToList();
           var rol = context.roles_permisos.Join(context.roles,
                    rp =>rp.rolid,
                    r =>r.id,
                    (rp,r) => new RolesPermisos{
                        id =rp.id,
                        rolid=rp.rolid,
                        moduloid =rp.moduloid,
                        visualizar=rp.visualizar,
                        crear=rp.crear,
                        borrar=rp.borrar,
                        editar=rp.editar,
                        imprimir=rp.imprimir,
                        rol = new Roles{
                            id=r.id,
                            rol=r.rol,

                        }
                    }
                    ).Where(e =>e.rolid==id).ToList();
                    
            return rol;
        }//lista los permisos del rol

        public int crearRolPermiso(string nombrerol,List<RolesPermisos> permisos){
            int response = 0;
            using(var transaccion = context.Database.BeginTransaction())
            {
                try
                {   
                    Roles newrol = new Roles{
                        rol= nombrerol,
                        borrado= false
                    };//crea el objecto
                    context.roles.Add(newrol); //agregamos el objecto
                    context.SaveChanges(); //salvamos los cambios
                    if(newrol.id <= 0){
                        throw new Exception("Error al crear el nombre del rol");
                    }
                    //crea el encabezado del rol y lo guarda en caso de error termina la transaccion
                    foreach(var permiso in permisos){
                        permiso.rolid = newrol.id;
                        context.roles_permisos.Add(permiso);
                        context.SaveChanges();
                    }//ejecuta el ciclo y guarda todos los permisos
                    transaccion.Commit();//se confirma la transaccion
                    response= newrol.id;
                    return response; //retorna la respuesta
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                    
                }//caso de error obtenemos la captura y retornamos el mensaje
            }
            
        }//crea el rol con sus permisos

        public int updateRolPermisos(rolUpdate data){
            using(var transaccion = context.Database.BeginTransaction())
            {
                try
                {
                    var oldrol = context.roles.Find(data.rolid);
                    if(oldrol.rol != data.nombre){
                        oldrol.rol = data.nombre;
                        context.SaveChanges();
                    }
                    //valiamos si cambio el nombre // hacemos el update del nombre del rol
                    foreach(var permiso in data.permisos){
                        var oldpermiso = context.roles_permisos.Find(permiso.id);
                        oldpermiso.visualizar = permiso.visualizar;
                        oldpermiso.crear = permiso.crear;
                        oldpermiso.editar = permiso.editar;
                        oldpermiso.borrar = permiso.borrar;
                        oldpermiso.imprimir = permiso.imprimir;
                        context.SaveChanges();
                    } //actualizo los permisos del rol
                    transaccion.Commit();//se confirma la transaccion
                    return 0; //retornamos 0 no hay error

                }
                catch (Exception e)
                { 
                    throw new Exception(e.Message);
                }
            }
        }//actualiza el rol y sus permisos

        public int borrar(int idrol){
            if(context.roles.Any(e => e.id == idrol)){
                var rol = context.roles.Find(idrol);
                rol.borrado = true;
                context.SaveChanges();
                 return 0; //retorna 0 borrado exitoso
            }else{
                return 1; //no existe el rol
            }
           
        }//borrado logico de roles

        public bool permiso(int rol,int modulo,int permiso){
            bool res = false;
            var permisos = context.roles_permisos
            .Where(e => e.rolid == rol && e.moduloid == modulo).First(); //consulta el permiso
            if(permisos !=null){
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
            }
            return res;

        }//revisa el permiso del usuario para saber si tiene o no acceso

    }
}