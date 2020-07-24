$(document).ready(e =>{
    listarRoles();
    $("#btnew").click(e=>{
        $("#modal").modal('show');
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
    if($("#nombres").val().length()<=0){
        $("#nombres").addClass("is-invalid");
        res = false;
    }else{
        $("#nombres").removeClass("is-invalid");
    }
    if($("#apellidos").val().length()<=0){
        $("#apellidos").addClass("is-invalid");
        res = false;
    }else{
        $("#apellidos").removeClass("is-invalid");
    }
    if($("#usuario").val().length()<=0){
        $("#usuario").addClass("is-invalid");
        res = false;
    }else{
        $("#usuario").removeClass("is-invalid");
    }
    if($("#clave").val().length()<=0){
        $("#clave").addClass("is-invalid");
        res = false;
    }else{
        $("#clave").removeClass("is-invalid");
    }
    if($("#clave2").val().length()<=0){
        $("#clave2").addClass("is-invalid");
        res = false;
    }else{
        $("#clave2").removeClass("is-invalid");
    }
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

