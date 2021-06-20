const btnuevo = document.getElementById('btnew')
const btnmateria =document.getElementById('btnmateriadd')
const btncarrera = document.getElementById('btncarreraadd')
const tablaCarreras =document.getElementById('tcarreras')
const tablaMaterias = document.getElementById('tmaterias')
const tablaMateriasAdd = document.getElementById('tblmateriaselect')
const tablaCarrerasAdd = document.getElementById('tblcarreraselect')
const modalMateria=$('#modalmateria')
const modalCarrera=$('#modalcarrera')
let boleta ={
    materias:[]
}


const statusCode = (request,mensaje)=>{
    let response =true
    switch(request.status){
        case 200:{
            response.response=true
            break
        }
        case 404:{
            Swal.fire({
                icon:'warning',
                title:'Advertencia',
                text:`recurso ${mensaje} no encontrado`
            })
            response.response=false
            break
        }
        case 500:{
            Swal.fire({
                icon:'warning',
                title:'Advertencia',
                text:'ha ocurrido un error al obtener el recurso'
            })
            response.response=false
            break
        }
        case 400:{
            Swal.fire({
                icon:'warning',
                title:'Advertencia',
                text:`${mensaje} parametros invalidos`
            })
            response.response=false
            break
            
        }
        default:{
            Swal.fire({
                icon:'warning',
                title:'Advertencia',
                text:'ha ocurrido un error inesperado'
            })
            response.response=false
            break
        }
    }
    return response
}//procesa el response

const quitarMateria =(id)=>{
    let nmateria = boleta.materias.map(e=>{
        return e!=id
    })
    boleta.materias=nmateria
    document.getElementById(`m${id}`).remove()
}

const agregarMateria=(id,nombre)=>{
    let respuesta =boleta.materias.filter(m=>m===id)
    if(respuesta.length ===0){
        boleta.materias.push(id)
        let tr=document.createElement('tr')
            tr.id=`m${id}`
            tr.innerHTML=`
            <td>${nombre}</td>
            <td><button type="button" class="btn btn-danger btn-sm "
            onClick="quitarMateria(${id})">X</button></td>`
        tablaMaterias.appendChild(tr)
    }
    modalMateria.modal('hide')
   
    //prevent.preventDefault()
}


const armarTablaMaterias =(materias)=>{
    //tablaMaterias.innerHTML=''
    let contador=1
    materias.forEach(m=>{
        let tr=document.createElement('tr')
        tr.onclick =(e)=>{
            e.preventDefault()
            agregarMateria(m.id,m.materia)
        }  
        tr.innerHTML=`<td>${contador}</td>
        <td>${m.materia}</td>`
        tablaMateriasAdd.appendChild(tr)
    })
}

const listarMaterias = async ()=>{
    try {
        const request = await fetch('/Materia/list')
        let response = statusCode(request,'materias')
        if(response){
            let data = await request.json()
            let materias = data.value 
            armarTablaMaterias(materias)
        }

    } catch (error) {
        Swal.fire({
            icon:'warning',
            title:'Algo ha ocurrido',
            text:error
        })
    }
}


$(document).ready(e=>{
    listarMaterias()
    btnuevo.onclick = ()=>{
        $('#modal').modal('show')
    }

    btnmateria.onclick =()=>{
        modalMateria.modal('show')
    }
})