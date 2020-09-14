$(document).ready(e=>{
    $('#btnew').click(e=>{
        $('#modal').modal('show');
    });//muestra el modal
<<<<<<< HEAD
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
=======

    $('#btnsave').click(e => {
        add();
    });
    showImage();
}); 


function validateForm() {
    var res = true;
    const campos = ['codigo', 'producto', 'marca', 'modelo', 'existencia'];
    campos.forEach(e => {
        var name = '#' + e;
        if ($(name).val().length > 0) {
            $(name).removeClass("is-invalid");
        } else {
            $(name).addClass("is-invalid");
            res = false;
        }
    });
    return res;
} //valida el formulario 

function showImage() {
    $('#archivo').change(function() {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (i) {
                console.log(i.target.result);
                $("#img").attr('src', i.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    }); 
} //muestra la imagen cuando se ha cargado

function add() {
    if (validateForm()) {

    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Campos Vacios',
            text: 'Debes llenar los campos obligatorios'
        });
    }
}
>>>>>>> 68029ef6733b964cafc9f3551ae6f918282ff6ba
