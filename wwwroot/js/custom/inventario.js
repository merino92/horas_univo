$(document).ready(e=>{
    $('#btnew').click(e=>{
        $('#modal').modal('show');
    });//muestra el modal

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