const armarlista=(datos)=>{
    if(datos.length >0){
        var html='';
        datos.forEach(e=>{
            let producto=`,'${e.codigo}','${e.nombre}'`;
            let row='<tr>';
            row+='<td>'+e.id+'</td>';
            row+='<td>'+e.codigo+'</td>';
            row+='<td>'+e.nombre+'</td>';
            row+='<td>'+e.existencia+'</td>';
            row+='<td><button class="btn btn-warning" onclick="historial('+e.id+producto+')" ><i class="fa fa-search" aria-hidden="true"></i></button></td>';
           row+='</tr>';
           html+=row;
        });
        $('#tabla').html(null);
        $('#tabla').html(html);
    }else{
        $('#tabla').html(null);
        $('#tabla').html('<h3>No se Encontraron resultados</h3>');
    }
};//crea la lista de productos

const listarProductos= async()=>{
    try{
        const respuesta= await axios.get('/Producto/list');
        if(respuesta.status !=200){
            throw Error('error al procesar la respuesta');
        }
        let datos=respuesta.data.value;
        armarlista(datos);
    }catch(error){
        console.log(error);
    }
};//lista los productos

const  busqueda = async (codigo,descripcion)=>{
    try{
        const parametros={params:{
            codigo:codigo.toUpperCase(),
            descripcion:descripcion.toUpperCase()
        }};
        const resultado= await axios.get('/Producto/search',parametros);                   
        if(resultado.status != 202){
            throw Error('Error al procesar la respuesta');
        }                        
        let datos=resultado.data.value;
       armarlista(datos);                     
    }catch(error){
        Swal.fire({
            icon:'warning',
            title:'Algo ha ocurrido',
            text:error
        });
    }

}//filtro de busqueda 

const historial= async (id,codigo,nombre)=>{
    $('#codigo').text(codigo);
    $('#nombre').val(nombre);
    let fecha=moment().format('YYYY-MM-DD');
    $('#fi').val(fecha);
    $('#ff').val(fecha);
    $('#modal').modal('show'); 
    try{
        let datos={
            params:{
                id:id,
                fi:"2020-11-02",
                ff:fecha,
                caso:1
            }
        };
        const respuesta=await axios.get('/Historial/search',datos);
        console.log(respuesta);
    }catch(error){
        console.log(error);
    }

};

$(document).ready(e=>{
    listarProductos();
    $('#btnbuscar').click(e=>{
        const codigo=$('#cbuscar').val();
        const descripcion=$('#pbuscar').val();
        if(codigo.length > 0 || descripcion.length > 0){
            busqueda(codigo,descripcion);
        }else{
            listarProductos();
        }
    });
});

