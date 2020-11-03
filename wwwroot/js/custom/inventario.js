$(document).ready(e=>{
    $('#btnew').click(e=>{
        $('#btnsave').show();
        $('#btnupdate').hide();
        $('#modal').modal('show');
    });//muestra el modal
    listar();
    $('#btnsave').click(e=>{
        add();
    });

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

function clear(){
    var formulario=['codigo','producto','marca','modelo','detalle','existencias'];
    formulario.forEach(key =>{
        var id="#"+key;
       var campo=$('#'+key).val(null)
    });
}

function createProducto(){
    if(validateForm){
        var datos={
            id:0,
            codigo:$("#codigo").val().trim().toUpperCase(),
            nombre:$("#producto").val().trim().toUpperCase(),
            marca:$("#marca").val().trim().toUpperCase(),
            modelo:$("#modelo").val().trim().toUpperCase(),
            detalle:$("#detalle").val().trim().toUpperCase(),
            existencia:parseInt($("#existencia").val()),
            nombreimagen:"",
            imagen:'',
        };
        console.log(datos);
        $.ajax({
            type: 'POST',
            url: '/Producto/create',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data:JSON.stringify(datos),
            success: data => {
                if(data.request <= 0){
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: data.response,
                        confirmButtonText: 'Aceptar'
                    });
                }else{
                    listar();
                    $('#modal').modal('hide');
                    Swal.fire({
                        icon: 'success',
                        title: 'Exito!!',
                        text: data.response,
                        confirmButtonText: 'Aceptar'
                    });
                }
    
            }, error: error=> {
                console.log(error);
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


function listar(){
    $.ajax({
        type: 'GET',
        url: '/Producto/list',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: data => {
           var productos=data.value;
           var html=null;
           productos.forEach(e=>{
               let row='<tr>';
                row+='<td>'+e.id+'</td>';
                row+='<td>'+e.codigo+'</td>';
                row+='<td>'+e.nombre+'</td>';
                row+='<td>'+e.existencia+'</td>';
                row+='<td><button class="btn btn-warning" onclick="editar('+e.id+')" ><i class="fa fa-wrench" aria-hidden="true"></i></button>';
                row+='<button class="btn btn-danger ml-2" onclick="eliminar('+e.id+')" ><i class="fa fa-trash" aria-hidden="true"></i></button></td>';
               row+='</tr>';
               html+=row;
           });
           $('#tabla').html(null);
           $('#tabla').html(html);
        }, error: error=> {
            console.log(error);
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error,
                confirmButtonText: 'Aceptar'

            });
        }
    }); //termina ajax
}//lista los productos   


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
        createProducto();
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Campos Vacios',
            text: 'Debes llenar los campos obligatorios'
        });
    }
} 

const borradologico =(id) =>{
    $.ajax({
        type: 'DELETE',
        url: `/Producto/delete/?id=${id}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: data => {
            var res= data.value;
            if(res.request >0){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: res.response,
                    confirmButtonText: 'Aceptar'
                });
            }else{
                listar();
                Swal.fire({
                    icon: 'success',
                    title: 'Exito',
                    text: "Producto Eliminado",
                    confirmButtonText: 'Aceptar'
                });
            }
        }, error: error=> {
            console.log(error.responseJson.value);
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error,
                confirmButtonText: 'Aceptar'
            });
        }
    }); //termina ajax
};


const eliminar=(id)=>{
    Swal.fire({
        icon:'warning',
        title:'Estas seguro de Eliminar este producto',
        showCancelButton: true,
        confirmButtonText:'eliminar',
        cancelButtonText:'cancelar'
    }).then((result)=>{
        if(result.isConfirmed){
            borradologico(id);
        }
    });
}//elimina el producto
var idglobal=0;
const editar = async (id)=>{
    try {
        
        const respuesta = await axios.get(`/Producto/listbyid/?id=${id}`);
        if(respuesta.status !=200){
            var error="Error al mostrar datos";
            if(respuesta.data !=null && respuesta.data != undefined ){
                error=respuesta.data.value.response;
            }   
            throw Error(error);
        }  
        const datos=respuesta.data.value;
        $('#codigo').val(datos.codigo);
        $('#producto').val(datos.nombre);
        $('#marca').val(datos.marca);
        $('#modelo').val(datos.modelo);
        $('#existencia').val(datos.existencia);
        $('#detalle').val(datos.detalle);
        $('#btnsave').hide();
        $('#btnupdate').show();
        $('#modal').modal('show');
        
    } catch (error) {
        console.log(error);
    }

}//obtiene los datos del producto

