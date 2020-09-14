$(document).ready(e=>{
    $('#btnew').click(e=>{
        $('#modal').modal('show');
    });//muestra el modal
}); 


function validateForm(){
    var respuesta=true;
    var formulario=['codigo','producto','marca','modelo','detalle','existencias'];
    formulario.forEach(key =>{
        var id="#"+key;
       var campo=$('#'+key).val();
       if(campo.length()>0){
        $(id).removeClass("is-invalid");
       }else{
        $(id).addClass("is-invalid");
        respuesta=false;
       }
    });
    return respuesta;
}//valida el formulario 


function createProducto(){
    if(validateForm){
        var datos={
            id:0,
            codigo:$("#codigo").val().trim().toUpperCase(),
            nombre:$("#producto").val().trim().toUpperCase(),
            marca:$("#marca").val().trim().toUpperCase(),
            modelo:$("#modelo").val().trim().toUpperCase(),
            detalle:$("#detalle").val().trim().toUpperCase(),
            existencia:parseInt($("#existencias").val())
        };
        $.ajax({
            type: 'POST',
            url: '/inventario',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data:JSON.stringify(datos),
            success: function (data) {
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
    }else{
        Swal.fire({
            icon: 'error',
            title: 'Advertencia !!',
            text: "Debes llenar los campos obligatorios",
            confirmButtonText: 'Aceptar'
        }); 
    }
}//crea el producto