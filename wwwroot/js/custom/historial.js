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
var idglobal=0;
const historial= async (id,codigo,nombre)=>{
    idglobal=id;
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
                fi:fecha,
                ff:fecha,
                caso:1
            }
        };
        const respuesta=await axios.get('/Historial/search',datos);
        console.log(respuesta);
        if(respuesta.status != 202){
            throw Error('Error al obtener la informacion intenta nuevamente');
        }
        armarResultados(respuesta.data.value);
    }catch(error){
        console.log(error);
    }

};
const evaluarFiltro=()=>{
    var fecha_inicio = new Date($('#fi').val());
    var fecha_fin = new Date($('#ff').val());
    if(fecha_inicio == fecha_fin){
        return {
            id:0,
            fi:moment($('#fi').val()).format('YYYY-MM-DD'),
            ff:moment($('#ff').val()).format('YYYY-MM-DD'),
            caso:1
        };
    } else if(fecha_fin > fecha_inicio){
        return {
            id:0,
            fi:moment($('#fi').val()).format('YYYY-MM-DD'),
            ff:moment($('#ff').val()).format('YYYY-MM-DD'),
            caso:2
        };
    }else{
        return {
            id:0,
            fi:moment($('#fi').val()).format('YYYY-MM-DD'),
            ff:moment($('#ff').val()).format('YYYY-MM-DD'),
            caso:1
        };
    }
}; //evalua las fechas para saber que  filtro regresar
const filtrarHistorial= async ()=>{
    try{
        var caso=evaluarFiltro();
        console.log(caso);
        caso.id=idglobal;
        let datos={
            params:caso
        };
        const respuesta=await axios.get('/Historial/search',datos);
        if(respuesta.status != 202){
            throw Error('Error al obtener la informacion intenta nuevamente');
        }
        armarResultados(respuesta.data.value);
    }catch(error){
        console.log(error);
    }
};

const armarResultados=(data)=>{
    console.log(data);
    var html='';
    if(data.length > 0){
        data.forEach(e=>{
            let fecha=  new Date(e.fecha);
            let f =moment(fecha).format("DD/MM/YYYY");
            let data = `<tr class="text-center" onclick="mostrarConcepto(${"'"+e.concepto+"'"})" >`;
            data+=`<td>${f}</td>`;
            data+=`<td>${e.documento}</td>`;
            data+=`<td>${e.usuario}</td>`;
            data+=`<td>${e.entrada}</td>`;
            data+=`<td>${e.salida}</td>`;
            data+=`<td>${e.saldo}</td>`;
            data += '</tr>';
            html+=data;
        });
    }
    $('#thistorial').html(null);
    $('#thistorial').html(html);
};//arma la tabla del historial

const mostrarConcepto = (concepto) =>{
    $('#concepto').val(concepto);
}; //muestra el concepto del detalle de historial

const imprimirInforme = () =>{
    const informe = new  jsPDF('p', 'mm', 'letter');
    informe.text('Movimientos de Inventario',15,7);
    informe.text($('#nombre').val(),5,14);
    informe.autoTable({
        html:"#tinforme",
        margin:{top:21}
    });
    
    informe.save('prueba.pdf');

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
    $('#btnfiltrar').click(e=>{
        filtrarHistorial();
    });
    $('#btnimprimir').click(e=>{
        imprimirInforme();
    });
});

