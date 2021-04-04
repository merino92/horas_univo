const btnbusqueda=document.getElementById('btnbuscar')
const btnnew=document.getElementById('btnew')
const btnadd=document.getElementById('btnsave')
const btnupdate = document.getElementById('btnupdate')
const inputbuscar = document.getElementById('mbuscar')
const inputmateria = document.getElementById('materia')
const modal = $('#modal')
const modaltitulo = document.getElementById('titulo')
const tabla = document.getElementById('tabla')

const clear =()=>{
    modaltitulo.innerText=''
    inputmateria.value=null
    idglobal=0
}

const filtroBusqueda=()=>{
    if(inputbuscar.value !=""){
        search(inputbuscar.value)
    }else{
        listar()
    }
}//revisa la  busqueda

const search = async(dato)=>{
    try {
        const request = await fetch(`/Materia/search?busqueda=${dato.toUpperCase()}`)
        const response = await request.json()
        if(request.status ===200){
         const datos =response.value 
         const tbl = armarlista(datos)
         tabla.innerHTML=tbl   
        }else{
            const mensaje =response.value 
            if(mensaje.hasOwnProperty('mensaje')){
                Swal.fire({
                    icon:'warning',
                    title:'Algo ha ocurrido',
                    text:mensaje.mensaje
                })
            }else{
                Swal.fire({
                    icon:'warning',
                    title:'Algo ha ocurrido',
                    text:'Ocurrio un error inesperado intenta nuevamente'
                })
            }
            
        }
    } catch (error) {
        console.log(error)
        Swal.fire({
            icon:'warning',
            title:'Algo ha ocurrido',
            text:'Ocurrio un error inesperado intenta nuevamente'
        })
    }
}

const acciones = ()=>{
    btnnew.onclick =()=>{
        clear()
        btnadd.style.display=''
        btnupdate.style.display='none'
        modaltitulo.innerText='Nueva Materia'
        modal.modal('show')
    }

    btnadd.onclick =()=>{
        create()
    }

    btnupdate.onclick=()=>{
        update()
    }

    inputbuscar.onkeypress =(e)=>{
        if(e.key==='Enter'){
            filtroBusqueda()
        }
    }
    btnbusqueda.onclick =()=>{
        filtroBusqueda()
    }
} 

const armarlista=(data)=>{
    let html =''
    let contador=0
    data.forEach(e=>{
        contador++
        html+=`<tr>
        <td>${contador}</td>
        <td>${e.materia}</td>
        <td><button class="btn btn-warning btn-sm" onclick="mostrar(${e.id})"><i class="fa fa-wrench" aria-hidden="true"></i></button>
        <button class="btn btn-danger btn-sm ml-2" onclick="eliminar(${e.id},'${e.materia}')" ><i class="fa fa-trash" aria-hidden="true"></i></button>
        </td>
        </tr>`
    })
    return html
} //arma la tabla

const listar = async ()=>{
    try {
        const request = await fetch('/Materia/list')
        const response = await request.json()
        
        if(request.status ===200){
         const datos =response.value 
         const tbl = armarlista(datos)
         tabla.innerHTML=tbl   
        }else{
            const mensaje =response.value 
            if(mensaje.hasOwnProperty('mensaje')){
                Swal.fire({
                    icon:'warning',
                    title:'Algo ha ocurrido',
                    text:mensaje.mensaje
                })
            }else{
                Swal.fire({
                    icon:'warning',
                    title:'Algo ha ocurrido',
                    text:'Ocurrio un error inesperado intenta nuevamente'
                })
            }
            
        }
    } catch (error) {
        console.log(error)
        Swal.fire({
            icon:'warning',
            title:'Algo ha ocurrido',
            text:'Ocurrio un error inesperado intenta nuevamente'
        })
    }
} 

const create = async ()=>{
    try {
        if(inputmateria.value!=''){
            const request = await fetch('/Materia/create',{
                method:'POST',
                headers:{
                    'Content-Type': 'application/json'
                },
                body:JSON.stringify({
                    id:0,
                    materia:inputmateria.value.trim().toUpperCase(),
                    borrado:false,
                    boletamaterias:null
                })
            })
            const response = await request.json()
            if(request.status ===201){
                listar()
                modal.modal('hide')
                clear()
                Swal.fire({
                    icon:'success',
                    title:'Exito',
                    text:'Materia creada'
                })

            }else{
                const mensaje =response.value 
                if(mensaje.hasOwnProperty('mensaje')){
                    Swal.fire({
                        icon:'warning',
                        title:'Algo ha ocurrido',
                        text:mensaje.mensaje
                    })
                }else{
                    Swal.fire({
                        icon:'warning',
                        title:'Algo ha ocurrido',
                        text:'Ocurrio un error inesperado intenta nuevamente'
                    })
                }
            }
        }else{
            Swal.fire({
                icon:'warning',
                title:'Advertencia',
                text:'Debes Ingresar el nombre de la materia'
            }) 
        }
        
    } catch (error) {
        console.log(error)
        Swal.fire({
            icon:'error',
            title:'Advertencia',
            text:'Ha ocurrido algo intenta nuevamente'
        })
    }
}

const borradologico = async (id)=>{
    try {
        const request = await fetch(`/Materia/delete?id=${id}`,{
            method:'DELETE',
        })
        const response = await request.json();
        if(request.status===200){
            listar()
            Swal.fire({
                icon:'success',
                title:'Exito',
                text:'Materia creada'
            })
        }else{
            const mensaje =response.value 
            if(mensaje.hasOwnProperty('mensaje')){
                Swal.fire({
                    icon:'warning',
                    title:'Algo ha ocurrido',
                    text:mensaje.mensaje
                })
            }else{
                Swal.fire({
                    icon:'warning',
                    title:'Algo ha ocurrido',
                    text:'Ocurrio un error inesperado intenta nuevamente'
                })
            }
        }
        
    } catch (error) {
        console.log(error)
        Swal.fire({
            icon:'error',
            title:'Advertencia',
            text:'Ha ocurrido algo intenta nuevamente'
        })
    }
} 
var idglobal=0;
const mostrar = async(id)=>{
    try {
        const request = await fetch(`/Materia/getId?id=${id}`)
        const response = await request.json()
        if(request.status===200){
            const materia = response.value
            idglobal=materia
            inputmateria.value=materia.materia
            btnupdate.style.display=''
            btnadd.style.display='none'
            modaltitulo.innerText='Datos de Materia'
            modal.modal('show')
        }else{
            const mensaje =response.value 
            if(mensaje.hasOwnProperty('mensaje')){
                Swal.fire({
                    icon:'warning',
                    title:'Algo ha ocurrido',
                    text:mensaje.mensaje
                })
            }else{
                Swal.fire({
                    icon:'warning',
                    title:'Algo ha ocurrido',
                    text:'Ocurrio un error inesperado intenta nuevamente'
                })
            } 
        }

    } catch (error) {
        console.log(error)
        Swal.fire({
            icon:'error',
            title:'Advertencia',
            text:'Ha ocurrido algo intenta nuevamente'
        })
    }
}

const eliminar =(id,nombre)=>{
    Swal.fire({
        icon:'warning',
        title:`Estas seguro de Eliminar la Materia ${nombre}`,
        showCancelButton: true,
        confirmButtonText:'eliminar',
        cancelButtonText:'cancelar'
    }).then((result)=>{
        if(result.isConfirmed){
            borradologico(id);
        }
    });
} 

const update = async ()=>{
    try {
        if(idglobal !=null){
            if(inputmateria.value !=''){
                idglobal.materia=inputmateria.value.trim().toUpperCase()
                const request = await fetch('/Materia/update',{
                    method:'PUT',
                    headers:{
                        'Content-Type': 'application/json'
                    },
                    body:JSON.stringify(idglobal)
                })
                const response = request.json()
                console.log(response)
                if(request.status===200){
                    listar()
                    modal.modal('hide')
                    clear()
                    Swal.fire({
                        icon:'success',
                        title:'Exito',
                        text:'Materia Actualizada'
                    })

                }else{
                    const mensaje =response.value 
                    if(mensaje.hasOwnProperty('mensaje')){
                        Swal.fire({
                            icon:'warning',
                            title:'Algo ha ocurrido',
                            text:mensaje.mensaje
                        })
                    }else{
                        Swal.fire({
                            icon:'warning',
                            title:'Algo ha ocurrido',
                            text:'Ocurrio un error inesperado intenta nuevamente'
                        })
                    } 
                }
            }else{
                Swal.fire({
                    icon:'error',
                    title:'Advertencia',
                    text:'Debes Ingresar el nombre de la materia'
                })
            }
        }else{
            Swal.fire({
                icon:'error',
                title:'Advertencia',
                text:'Ha ocurrido algo al intenta actualizar intenta nuevamente'
            }) 
        }
    } catch (error) {
        console.log(error)
        Swal.fire({
            icon:'error',
            title:'Advertencia',
            text:'Ha ocurrido algo intenta nuevamente'
        })
    }
}

$(document).ready(e=>{
   acciones()
   listar()
})