$(document).ready(e =>{
    listarUsuarios();
    listarRoles();
    $("#btnew").click(e=>{
        $("#btnadd").show();
        $("#btnupdate").hide();
        block(false);
        clearForm();
        $("#modal").modal('show');
    });

    $("#btnadd").click(e=>{
        crear();
    });//boton guardar
    $("#btnupdate").click(e=>{
        update();
    });

});

function listarRoles(){
    $.ajax({
        type: 'GET',
        url: '/Roles/list/',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend:function(){
        },
        success: function (data) {
            if(data.request > 0){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: data.response
                });
            }else{
                var html =null;

                data.roles.forEach(e =>{
                    html+='<option value="'+e.id+'">'+e.rol+'</option>'
                });
                $("#rol").html(null);
                $("#rol").html(html);
            } //termina else
        }, error: function (xhr, status, error) {
            Swal.close();
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error

            });
        }
    }); //termina ajax
} //lista los roles de usuario

function validarForm(){
    var res = true;
    var nombre =$("#nombres").val();
    var apellido=$("#apellidos").val();
    var usuario =$("#usuario").val();
    var clave =$("#clave").val();
    var clave2=$("#clave2").val();
    if(nombre.length<=0){
        $("#nombres").addClass("is-invalid");
        res = false;
    }else{
        $("#nombres").removeClass("is-invalid");
    }
    if(apellido.length<=0){
        $("#apellidos").addClass("is-invalid");
        res = false;
    }else{
        $("#apellidos").removeClass("is-invalid");
    }
    if(usuario.length<=0){
        $("#usuario").addClass("is-invalid");
        res = false;
    }else{
        $("#usuario").removeClass("is-invalid");
    }
    if(clave.length<=0){
        $("#clave").addClass("is-invalid");
        res = false;
    }else{
        $("#clave").removeClass("is-invalid");
    }
    if(clave2.length<=0){
        $("#clave2").addClass("is-invalid");
        res = false;
    }else{
        $("#clave2").removeClass("is-invalid");
    }
    console.log(res);
    return res
}//valida todos los campos del formulario

function validarClave(){
    const c1 =$("#clave").val();
    const c2 =$("#clave2").val();
    if(c1 === c2){
        return true;
    }else{
        return false;
    }
} //valida que la clave se haya validado correctamente 

function clearForm(){
    $("#nombres").val(null);
    $("#apellidos").val(null);
    $("#usuario").val(null);
    $("#clave").val(null);
    $("#clave2").val(null);
    $("#rol").prop("selectedIndex", 0);   
} //limpiar el formulario

function listarUsuarios(){
    $.ajax({
        type: 'GET',
        url: '/Usuario/list/',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend:function(){
            Swal.fire({
                title: 'Cargando porfavor espere'
           });
           Swal.showLoading();
        },
        success: function (data) {
            Swal.close();
            
            if(data.request > 0){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: data.response
    
                });
            }else{ 
                var datos = data.response;
                $("#listado").html(null);
                var html = null;
                datos.forEach(key =>{
                    html+="<tr>";
                    html +='<td scope="col">'+key.id+'</td>';
                    html +='<td scope="col">'+key.usuario+'</td>';
                    html +='<td scope="col">'+key.nombres+" "+key.apellidos+'</td>';
                    html+='<td>';
                    html+='<button type="button" class="btn btn-info btn-sm mr-2" onClick="Mostrar(' + key.id + ',1,' +
                    ')" >Mostrar</button>';
                    html+='<button type="button" class="btn btn-warning btn-sm mr-2" onClick="Mostrar(' + key.id + ',0,' +
                    ')" >Editar</button>';
                    html+='<button type="button" class="btn btn-danger btn-sm" onClick="Eliminar(' + key.id + ',' +
                    "'" + key.usuario + "'" + ')" >Eliminar</button>';
                    html+='</td>';
                    html+="</tr>";  
                });
                $("#listado").html(html);
            }

        }, error: function (xhr, status, error) {
            Swal.close();
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error

            });
        }
    }); //termina ajax
}//lista todos los usuarios

function block(res){
    $("#nombres").prop("disabled",res);
    $("#apellidos").prop("disabled",res);
    $("#usuario").prop("disabled",res);
    $("#clave").prop("disabled",res);
    $("#clave2").prop("disabled",res);
    $("#rol").prop("disabled",res);  
}//bloquea o desbloquea el formulario
var idglobal =0; //guarda el id del usuario
function Mostrar(id,bloqueo){
    var bloqueado = Boolean(bloqueo);
    if(bloqueado){
        $("#btnadd").hide();
        $("#btnupdate").hide();
        block(true);
    }else{
        $("#btnadd").hide();
        $("#btnupdate").show();
        block(false);
    }
    $.ajax({
        type: 'GET',
        url: '/Usuario/listid/?id='+id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if(data.request > 0){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: data.response
    
                });
            }else{ 
                var datos = data.response;
                console.log(datos);
                idglobal =datos.id;
                $("#nombres").val(datos.nombres);
                $("#apellidos").val(datos.apellidos);
                $("#usuario").val(datos.usuario);
                $("#clave").val(datos.clave);
                $("#clave2").val(datos.clave);
                $("#rol").val(datos.rolid); 
                $("#modal").modal('show');
                
            }

        }, error: function (xhr, status, error) {
            Swal.close();
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error

            });
        }
    }); //termina ajax

}

function crear(){
    if(validarForm()){
        if(validarClave()){
            const datos={
                id:0,
                nombres:$("#nombres").val().trim().toUpperCase(),
                apellidos:$("#apellidos").val().trim().toUpperCase(),
                usuario:$("#usuario").val().toUpperCase(),
                clave:$("#clave").val(),
                rolid:parseInt($("#rol").val()),
                borrado:false
            };
            $.ajax({
                type: 'POST',
                url: '/Usuario/create/',
                data:JSON.stringify(datos),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend:function(){
                    Swal.fire({
                        title: 'Guardando porfavor espere'
                   });
                   Swal.showLoading();
                },
                success: function (data) {
                    //Swal.close();
                    console.log(data);
                    if(data.request > 0){
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: data.response,
                            confirmButtonText: 'Aceptar'
                        });
                    }else{ 
                        clearForm();//limpiamos el formulario
                        listarUsuarios();
                        Swal.fire({
                            icon: 'success',
                            title: 'Exito!!',
                            text: data.response,
                            confirmButtonText: 'Aceptar'
                        });
                        $("#modal").modal('hide');
                    }
        
                }, error: function (xhr, status, error) {
                    Swal.close();
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: error,
                        confirmButtonText: 'Aceptar'
                    });
                }
            }); //termina ajax

        }else{
            Swal.fire({
                icon: 'warning',
                title: 'Avertencia!!',
                text: 'Las claves no coinciden',   
              });
        } //valida la clave
    }else{
        Swal.fire({
            icon: 'warning',
            title: 'Avertencia',
            text: 'Debes llenar los campos obligatorios',   
          });
    }//valida que se hayan llenado el formulario
}//crea el usuario

function update(){
    if(validarForm()){
        if(validarClave()){
            const datos={
                id:idglobal,
                nombres:$("#nombres").val().trim().toUpperCase(),
                apellidos:$("#apellidos").val().trim().toUpperCase(),
                usuario:$("#usuario").val().toUpperCase(),
                clave:$("#clave").val(),
                rolid:parseInt($("#rol").val()),
                borrado:false
            };
            $.ajax({
                type: 'PUT',
                url: '/Usuario/update/',
                data:JSON.stringify(datos),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend:function(){
                    Swal.fire({
                        title: 'Guardando porfavor espere'
                   });
                   Swal.showLoading();
                },
                success: function (data) {
                    Swal.close();
                    console.log(data);
                    if(data.request > 0){
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: data.response
                            
                        });
                    }else{ 
                        clearForm();//limpiamos el formulario
                        listarUsuarios();
                        $("#modal").modal('hide');
                        Swal.fire({
                            icon: 'success',
                            title: 'Exito!!',
                            text: data.response
                        });
                    }
        
                }, error: function (xhr, status, error) {
                    Swal.close();
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: error
        
                    });
                }
            }); //termina ajax

        }else{
            Swal.fire({
                icon: 'warning',
                title: 'Avertencia!!',
                text: 'Las claves no coinciden',   
              });
        } //valida la clave
    }else{
        Swal.fire({
            icon: 'warning',
            title: 'Avertencia',
            text: 'Debes llenar los campos obligatorios',   
          });
    }//valida que se hayan llenado el formulario
}//actualiza  el usuario

function Eliminar(id, nombre){ 
    Swal.fire({
        title: 'Estas seguro de Eliminar el Usuario '+nombre,
        text: "Sera Permanente",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: 'bg-success',
        cancelButtonColor: 'bg-danger',
        cancelButtonText: 'Cancelar',
        confirmButtonText: 'Eliminar'
      }).then((result) => {
        if (result.value) {
            $.ajax({
                type: 'DELETE',
                url: '/Usuario/delete/?id=' + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    if(data.request > 0){
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: data.response,
                            confirmButtonText: 'Aceptar'
                        });
                    }else{
                        listarUsuarios();
                        
                        Swal.fire({
                            icon: 'success',
                            title: 'Exito!!',
                            text: data.response,
                            confirmButtonText: 'Aceptar'
                        });
                    }
        
                }, error: function (xhr, status, error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: error,
                        confirmButtonText: 'Aceptar'
        
                    });
                }
            }); //termina ajax
        }
      })
} //elimina los roles
