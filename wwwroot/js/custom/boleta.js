const btnuevo = document.getElementById('btnew')
<<<<<<< HEAD
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
=======
const modalboleta = $('#modal')
const modalbuscar = $('#modaldata')
const btnaddfacultad = document.getElementById('btnfacultadadd')
const tablafacultad = document.getElementById('tfacultad')
const btnaddcarrera = document.getElementById('btncarreradd')
const tablacarrera = document.getElementById('tcarreras')
const btnmateriadd = document.getElementById('btnmateriadd')
const tablamateria = document.getElementById('tmateria')
const codigoboleta = document.getElementById('nboleta')
const fechaboleta = document.getElementById('fecha')
const encargado = document.getElementById('encargado')
const tablaboletadetalle = document.getElementById('cuerpo')
const boleta = {
    fecha: null,
    encargado: null,
    facultad: [],
    carrera: [],
    materia: [],
    detalle:[]
>>>>>>> d10db13464fc6568da93c45dc74596be48baf766
}

const clean = () => {
    let fecha=new Date().toISOString().substring(0,10)
    fechaboleta.value =fecha
    tablafacultad.innerHTML = ''
    tablacarrera.innerHTML = ''
    tablamateria.innerHTML = ''
    tablaboletadetalle.innerHTML=''
}

<<<<<<< HEAD
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
=======
const Quitar = (id,numero) => 
{  
    switch (numero) {
        case 1:
            {
                let tr = document.getElementById(('ff' + id))
                boleta.facultad = boleta.facultad.map(x => {
                    if (x != id) return x
                })
                tr.parentNode.removeChild(tr)
                break
            }
        case 2: {
            let tr = document.getElementById(('cc' + id))
            boleta.carrera = boleta.carrera.map(x => {
                if (x != id) return x
            })
            tr.parentNode.removeChild(tr)
            break
        }
        default: {
            let tr = document.getElementById(('mm' + id))
            boleta.materia = boleta.materia.map(x => {
                if (x != id) return x
            })
            tr.parentNode.removeChild(tr)
            break
        }

    }
    
}


const AgregarFacultad = (id, nombre) => {
    if (!boleta.facultad.includes(id)) {
        let tr = document.createElement('tr')
        tr.id=`ff${id}`
        tr.innerHTML = `<td>${nombre}</td><td><button type="button" class="close" onclick="Quitar(${id},1)" >
                    <span aria-hidden="true">&times;</span>
                </button></td>`
        tablafacultad.appendChild(tr)
        boleta.facultad.push(id)
    }//valida que no se vuelva a repetir la facultad
    modalbuscar.modal('hide')
}

const AgregarCarrera = (id, nombre) => {
    if (!boleta.carrera.includes(id)) {
        let tr = document.createElement('tr')
        tr.id = `cc${id}`
        tr.innerHTML = `<td>${nombre}</td><td><button type="button" class="close" onclick="Quitar(${id},2)" >
                    <span aria-hidden="true">&times;</span>
                </button></td>`
        tablacarrera.appendChild(tr)
        boleta.carrera.push(id)
    }//valida que no se vuelva a repetir la facultad
    modalbuscar.modal('hide')
}

const AgregarMateria = (id, nombre) => {
    if (!boleta.materia.includes(id)) {
        let tr = document.createElement('tr')
        tr.id = `mm${id}`
        tr.innerHTML = `<td>${nombre}</td><td><button type="button" class="close" onclick="Quitar(${id},3)" >
                    <span aria-hidden="true">&times;</span>
                </button></td>`
        tablamateria.appendChild(tr)
        boleta.materia.push(id)
    }//valida que no se vuelva a repetir la facultad
    modalbuscar.modal('hide')
}


const listarFacultades = async () => {
    try {
        const request = await fetch('/Boleta/listarFacultades')
        if (request.status === 200) {
            const response = await request.json()
            console.log(response)
            const encabezado = document.getElementById('mencabezado')
            let tabla = document.getElementById('detalletbl')
            encabezado.innerHTML = `<th>Nombre de Facultad</th>`
            let html =''
            response.value.forEach(e => {
                html += `<tr onclick="AgregarFacultad(${e.id},'${e.nombre}')"><td>${e.nombre}</td></tr>`
            })
            tabla.innerHTML = html
            modalbuscar.modal('show')
        } else {
            throw 'Ocurrio un erro al obtener las facultades'
        }
    } catch (e) {
        console.log(e)
    }
}

const listarCarreras = async () => {
    try {
        const request = await fetch('/Boleta/listarCarreras')
        if (request.status === 200) {
            const response = await request.json()
            console.log(response)
            const encabezado = document.getElementById('mencabezado')
            let tabla = document.getElementById('detalletbl')
            encabezado.innerHTML = `<th>Nombre de Carrera</th>`
            let html = ''
            response.value.forEach(e => {
                html += `<tr onclick="AgregarCarrera(${e.id},'${e.carrerra}')"><td>${e.carrerra}</td></tr>`
            })
            tabla.innerHTML = html
            modalbuscar.modal('show')
        } else {
            throw 'Ocurrio un erro al obtener las facultades'
        }
    } catch (e) {
        console.log(e)
    }
}

const listarMaterias= async () => {
    try {
        const request = await fetch('/Materia/list')
        if (request.status === 200) {
            const response = await request.json()
            console.log(response)
            const encabezado = document.getElementById('mencabezado')
            let tabla = document.getElementById('detalletbl')
            encabezado.innerHTML = `<th>Nombre de Materia</th>`
            let html = ''
            response.value.forEach(e => {
                html += `<tr onclick="AgregarMateria(${e.id},'${e.materia}')"><td>${e.materia}</td></tr>`
            })
            tabla.innerHTML = html
            modalbuscar.modal('show')
        } else {
            throw 'Ocurrio un erro al obtener las Materias'
        }
    } catch (e) {
        console.log(e)
    }
}


const funciones = () => {
   
    btnuevo.onclick = () => {
        clean()
>>>>>>> d10db13464fc6568da93c45dc74596be48baf766
        $('#modal').modal('show')
    } 

    btnaddfacultad.onclick = () => {
        listarFacultades()
    }

    btnaddcarrera.onclick = () => {
        listarCarreras()
    }

<<<<<<< HEAD
    btnmateria.onclick =()=>{
        modalMateria.modal('show')
    }
=======
    btnmateriadd.onclick = () => {
        listarMaterias()
    } 


}


$(document).ready(e => {
    funciones()
>>>>>>> d10db13464fc6568da93c45dc74596be48baf766
})