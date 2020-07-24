$(document).ready( function(){
    ListRoles();
    ListarModulos();
    $("#btnew").click(e =>{
        $("#nombre").prop("disabled",false);
        $("#nombre").removeClass("is-invalid");
        $("#nombre").val(null);
        $("#btnupdate").hide();
        $("#btnadd").show();
        ListarModulos();
        $("#modal").modal('show'); //muestra el modal
    }); //hacer click en el boton de nuevo

    $("#btnadd").click(e =>{
        guardar();
    });//boton guardar del modal
    $("#btnupdate").click(e =>{
        update();
    });//boton guardar del modal
}); //funcion de inicio

function ListRoles(){
    $("#listado").html(null); //limpia la tabla
    $.ajax({
        type: 'GET',
        url: '/Roles/list/',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend:function(){
            Swal.fire({
                title: 'Cargando Porfavor Espere'
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
                var html =null;

                data.roles.forEach(e =>{
                    html+='<tr>';
                    html+='<td>'+e.id+'</td>';
                    html+='<td>'+e.rol+'</td>';
                    html+='<td>';
                    html+='<button type="button" class="btn btn-info btn-sm mr-2" onClick="Mostrar(' + e.id + ',1,' +
                    "'" + e.rol + "'" + ')" >Mostrar</button>';
                    html+='<button type="button" class="btn btn-warning btn-sm mr-2" onClick="Mostrar(' + e.id + ',0,' +
                    "'" + e.rol + "'" + ')" >Editar</button>';
                    html+='<button type="button" class="btn btn-danger btn-sm" onClick="Eliminar(' + e.id + ',' +
                    "'" + e.rol + "'" + ')" >Eliminar</button>';
                    html+='</td>';
                    html+='</tr>';
                });
                $("#listado").html(html);
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
}//lista los roles que existen
function formIsValid(){
    var res = true;
    var nombre =$("#nombre").val();
    if(nombre.length > 0){
        $("#nombre").removeClass("is-invalid");
    }else{
        $("#nombre").removeClass("is-valid");
        $("#nombre").addClass("is-invalid");
        res = false;
    }
    return res;
}//valida el nomnbre del perfil
var modulosid=[];
var rolidglobal =0;
function ListarModulos(){
    modulosid.length =0;
    $("#tblrol").html(null); //limpia la tabla
    var html = '';
    $.ajax({
        type: 'GET',
        url: '/Roles/listModulos',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.length > 0) {
                data.forEach(key => {
                    modulosid.push(key.id);
                    html+="<tr>";
                    html +='<td scope="col">'+key.modulo+'</td>';
                    html += checks(key.id,false);
                    html+="</tr>";  
                });
            }//verificamos que tenga datos la respuests
            $("#tblrol").html(html); //agregamos lo datos a la tabla

        }, error: function (xhr, status, error) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error

            });
        }
    }); //termina ajax
}

function checks(id,bloqueo){
    var blo ='';
    if(bloqueo ==true){
        blo='disabled';
    }
    var html = null;
    html +='<td class="text-center">';
    html +='<div class="form-check">';
    html +=' <input class="form-check-input" onClick="estadoCheck(' +
    "'" + ("ING"+id) + "'" + ')" type="radio" value="0" id="'+("ING"+id)+'" >';
    html +='</div>';
    html +='</td>';
    html +='<td class="text-center">';
    html +='<div class="form-check">';
    html +=' <input class="form-check-input" value="0" onClick="estadoCheck(' +
    "'" + ("CR"+id) + "'" + ')" type="radio" id="'+("CR"+id)+'" >';
    html +='</div>';
    html +='</td>';
    html +='<td class="text-center">';
    html +='<div class="form-check">';
    html +=' <input class="form-check-input" value="0" onClick="estadoCheck(' +
    "'" + ("MO"+id) + "'" + ')" type="radio" id="'+("MO"+id)+'" >';
    html +='</div>';
    html +='</td>';
    html +='<td class="text-center">';
    html +='<div class="form-check">';
    html +=' <input class="form-check-input" value="0" onClick="estadoCheck(' +
    "'" + ("EL"+id) + "'" + ')" type="radio" id="'+("EL"+id)+'" >';
    html +='</div>';
    html +='</td>';
    html +='<td class="text-center">';
    html +='<div class="form-check">';
    html +=' <input class="form-check-input" value="0" onClick="estadoCheck(' +
    "'" + ("IMP"+id) + "'" + ')" type="radio" id="'+("IMP"+id)+'" >';
    html +='</div>';
    html +='</td>';
    return html;
} //retorna checkbox dinamicos

function revisarPermisos(id){
    const check ="#"+id;
    return $(check).prop('checked');
}//retorna si esta chequeado o no

function getPermisos(){
    var matriz=[];
    var id =0,rolid=0;
    var i=0;
    modulosid.forEach(key =>{
        if(permisosdata.length >0){
            id=permisosdata[i].id;
            rolid=permisosdata[i].rolid;
            i++;
        }
        matriz.push({
            id:id,
            rolid:rolid,
            moduloid:parseInt(key),
            visualizar:revisarPermisos(("ING"+key)),
            crear:revisarPermisos(("CR"+key)),
            editar:revisarPermisos(("MO"+key)),
            borrar:revisarPermisos(("EL"+key)),
            imprimir:revisarPermisos(("IMP"+key)),

        });
    });
    return matriz;
}//obtiene todos los permisos

function guardar(){
    console.log(formIsValid());
    if(formIsValid()){
        var datos = {
            nombre:$("#nombre").val().toUpperCase(),
            permisos:getPermisos()
        };
        $.ajax({
            type: 'POST',
            url: '/Roles/create/',
            data:JSON.stringify(datos),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend:function(){
                Swal.fire({
                    title: 'Guardando Porfavor Espere'
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
                    ListRoles();
                    $("#modal").modal('hide');
                    Swal.fire({
                        icon: 'success',
                        title: 'Exito!!',
                        text: data.response
                    });
                    ListarModulos();
                    $("#nombre").val(null);
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
            title: 'Avertencia',
            text: 'Debes llenar los campos obligatorios',   
          });
    }

} //crea el rol y los permisos

function estadoCheck(id){
    if($("#"+id).prop("disabled")== false){
       
        if($("#"+id).val() > 0){
            
            $("#"+id).prop("checked", false);
            console.log($("#"+id).prop("checked"));
            $("#"+id).val(0);
        }else{
            $("#"+id).prop("checked", true);
            console.log($("#"+id).prop("checked"));
            $("#"+id).val(1);
        }
    
        
    }
} //revisa el estado de los radiobutton
function checkUncheck(e,res){
     $("#"+e).prop("checked", res);
     if (res){
        $("#"+e).val(1);
     }else{
        $("#"+e).val(0);
     }
       
}//habilita desahhabilita los checkbox
function bloquear(nombre,res){
    $("#"+nombre).prop("disabled", res);
    $("#nombre").prop("disabled",res);
} //bloquea o desbloquea los checkbox
var permisosdata=[];//se guardan los detalles del los permisos
function Mostrar(id,edicion,nombrerol){
    rolidglobal=id;
    $("#nombre").removeClass("is-invalid");
    var edit =Boolean(edicion);
    $("#nombre").val(nombrerol);
    if(!edit){
        $("#btnupdate").show();
        $("#btnadd").hide();
    }else{
        $("#btnupdate").hide();
        $("#btnadd").hide();
    }
    $.ajax({
        type: 'GET',
        url: '/Roles/ListId/?id=' + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            if(data.request > 0){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: data.response
    
                });
            }else{
                const datos =data.permisos;
                permisosdata.length =0;
                datos.forEach(e =>{
                    permisosdata.push({
                        id:e.id,
                        rolid:e.rolid
                    });
                    bloquear(("ING"+e.moduloid),edit);
                    bloquear(("CR"+e.moduloid),edit);
                    bloquear(("MO"+e.moduloid),edit);
                    bloquear(("EL"+e.moduloid),edit);
                    bloquear(("IMP"+e.moduloid),edit);
                    checkUncheck(("ING"+e.moduloid),e.visualizar);
                    checkUncheck(("CR"+e.moduloid),e.crear);
                    checkUncheck(("MO"+e.moduloid),e.editar);
                    checkUncheck(("EL"+e.moduloid),e.borrar);
                    checkUncheck(("IMP"+e.moduloid),e.imprimir);
                });
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

function Eliminar(id, nombre){
    Swal.fire({
        title: 'Estas seguro de Eliminar el Perfil '+nombre,
        text: "Si hay un usuario con este perfil lo seguira conservando!",
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
                url: '/Roles/delete/?id=' + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    if(data.request > 0){
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: data.response
            
                        });
                    }else{
                        ListRoles();
                        Swal.fire({
                            icon: 'success',
                            title: 'Exito!!',
                            text: data.response
                        });
                    }
        
                }, error: function (xhr, status, error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: error
        
                    });
                }
            }); //termina ajax
        }
      })
} //elimina los roles

function update(){

    if(formIsValid()){
        var datos = {
            rolid:parseInt(rolidglobal),
            nombre:$("#nombre").val().toUpperCase(),
            permisos:getPermisos()
        };
        
        $.ajax({
            type: 'PUT',
            url: '/Roles/update/',
            data:JSON.stringify(datos),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend:function(){
                Swal.fire({
                    title: 'Actualizando Porfavor Espere'
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
                    ListRoles();
                    $("#modal").modal('hide');
                    Swal.fire({
                        icon: 'success',
                        title: 'Exito!!',
                        text: data.response
                    });
                    ListarModulos();
                    $("#nombre").val(null);
                    rolidglobal =0;
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
            title: 'Avertencia',
            text: 'Debes llenar los campos obligatorios',   
          });
    }

} //crea el rol y los permisos
