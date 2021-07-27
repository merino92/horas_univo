

const btnuevo = document.getElementById("btnew");
const modalboleta = $("#modal");
const modalbuscar = $("#modaldata");
const btnaddfacultad = document.getElementById("btnfacultadadd");
const tablafacultad = document.getElementById("tfacultad");
const btnaddcarrera = document.getElementById("btncarreradd");
const tablacarrera = document.getElementById("tcarreras");
const btnmateriadd = document.getElementById("btnmateriadd");
const tablamateria = document.getElementById("tmateria");
const codigoboleta = document.getElementById("nboleta");
const fechaboleta = document.getElementById("fecha");
const encargado = document.getElementById("encargado");
const modalInventario = $("#modalinventario");
const btnInventario = document.getElementById("btninventario");
const tablaboletadetalle = document.getElementById("cuerpo");
const tablaInventario = document.getElementById("inventariotbl");
const btnCrearBoleta = document.getElementById("btnsave");
const tablaBoleta = document.getElementById('tabla');
const boleta = {
  fecha: null,
  encargado: null,
  facultad: [],
  carrera: [],
  materia: [],
  detalle: [],
}; //objecto donde se crea toda la boleta

const Inventario ={
  facultad:[],
  materias:[],
  carreras:[]
}; 

const  tblboletas = (data)=>{
   tablaBoleta.innerHTML=null;
   let html ='';
   data.forEach((e,i)=>{
     let fecha = new Date(e.fecha);
      let btns=`<button type="button" class="btn btn-warning btn-sm"></button>
        <button type="button" onClick="alertaDelete(${e.id},'${e.codigo}')" class="btn btn-danger btn-sm">
          <i class="fa fa-trash" aria-hidden="true"></i>
        </button>`
      if(e.devuelto){
        btns=`<button type="button" class="btn btn-info btn-sm"></button>`
      }

     html+=`<tr>
     <td>${i+1}</td>
      <td>${e.codigo}</td>
      <td>${fecha.getDate()}/${(fecha.getMonth()+1)}/${fecha.getFullYear()}</td>
      <td>${(e.devuelto) ? "CERRADA":"ABIERTA"}</td>
      <td>${btns}</td>
     </tr>`;
   });
   tablaBoleta.innerHTML=html;
}

const listarBoletas = async ()=>{
  try {
    const  request = await fetch('/Boleta/list');
    
    if(request.ok){
      let response = await request.json();
      let boletas = response.value
      tblboletas(boletas);
    }else{
      Swal.fire({
        icon:'warning',
        title:'Advertencia',
        text:'No se pudo carga el listado de boletas',
        timer:2000
      });
    }
    
  } catch (error) {
    console.log(error)
    Swal.fire({
      icon:'error',
      title:'Advertencia',

    })
  }
}

const isJSON = (data) => {
  try {
    JSON.parse(data);
  } catch (error) {
    return false;
  }
  return true;
}; //VALIDA SI LA DATA ES JSON

const clean = () => {
  let fecha = new Date().toISOString().substring(0, 10);
  fechaboleta.value = fecha;
  boleta.fecha=null;
  boleta.encargado=null;
  boleta.materia=[];
  boleta.detalle=[];
  boleta.facultad=[];
  tablafacultad.innerHTML = "";
  tablacarrera.innerHTML = "";
  tablamateria.innerHTML = "";
  tablaboletadetalle.innerHTML = "";
};

const Quitar = (id, numero) => {
  switch (numero) {
    case 1: {
      let tr = document.getElementById("ff" + id);
      boleta.facultad = boleta.facultad.filter((f) => f !== parseInt(id));
      /*boleta.facultad.map((x) => {
        if (x != id) return x;
      });*/
      tr.parentNode.removeChild(tr);
      break;
    }
    case 2: {
      let tr = document.getElementById("cc" + id);
      boleta.carrera = boleta.carrera.filter((c) => c !== parseInt(id));
      /*boleta.carrera.map((x) => {
        if (x != id) return x;
      });*/
      tr.parentNode.removeChild(tr);
      break;
    }
    case 3:{
      let tr = document.getElementById('m'+id);
      boleta.detalle = boleta.detalle.filter( d => d.idproducto !==parseInt(id))
      tr.parentNode.removeChild(tr);
      break;
    }
    default: {
      let tr = document.getElementById("mm" + id);
      boleta.materia = boleta.materia.filter((m) => m !== parseInt(id));
      /*boleta.materia.map((x) => {
        if (x != id) return x;
      });*/
      tr.parentNode.removeChild(tr);
      break;
    }
  }
};

const limiteMax = (id,existencia)=>{
  let input = document.getElementById('c'+id);
  let cantidad = 1;
  if(parseInt(input.value) > 0 && parseInt(input.value) <=parseInt(existencia)){
      cantidad = parseInt(input.value);
  }else{
    if(parseInt(input.value) > parseInt(existencia)){
      input.value=parseInt(existencia);
      cantidad = parseInt(existencia);
    } 
    if(parseInt(input.value)===0){
      input.value=1
    }
    
    Swal.fire({
      icon:'warning',
      title:'Advertencia',
      text:'La cantidad del item no puede ser 0, ni ser mayor que la existencia',
      timer:2000
    });
  }
    boleta.detalle = boleta.detalle.map(d=>{
      if(d.idproducto === parseInt(id)){
        d.cantidad = cantidad;
      }
      return d;
  });
}

const validacionDatos = () => {
  let aval = false;
  let nameEncardo = encargado.value.trim();
  if (
    boleta.carrera.length > 0 &&
    boleta.facultad.length > 0 &&
    boleta.materia.length > 0 &&
    boleta.detalle.length > 0 &&
    nameEncardo.length > 0
  ) {
    aval = true; 
    nameEncardo = nameEncardo.trim().toUpperCase();
    boleta.detalle = boleta.detalle.map((b) => {
      let item = `c${b.idproducto}`;
      let valor = parseInt(document.getElementById(item).value);
      if (valor > 0) {
        aval = true;
      }
      return b;
    });
  }
  let boletaFinal = {
    encargado: nameEncardo,
    detalle: boleta.detalle,
    carreras: boleta.carrera,
    facultad: boleta.facultad,
    materias: boleta.materia,
  };
  return {
    boleta: boletaFinal,
    validation: aval,
  };
};

const materialAdd = (id, codigo, nombre,existencia) => {
  let existe = boleta.detalle.filter((i) => i.idproducto === id);
  if (existe.length === 0) {
    boleta.detalle.push({ idproducto: parseInt(id), cantidad: 1 });
    let tr = document.createElement("tr");
    tr.id = `m${id}`;
    tr.innerHTML = ` <td>${codigo}</td>
    <td>${nombre}</td>
    <td><div class="d-inline-flex"><input type="number"   
    class="form-control form-control-sm input-cantidad"
    onChange="limiteMax(${id},${existencia})"
    id="c${id}" value="1"/></div></td>
        <td><button type="button" class="btn btn-sm btn-danger" onClick="Quitar(${id},3)">X</button></td>`;
    tablaboletadetalle.appendChild(tr);
  }
  modalInventario.modal("hide");
};

const AgregarFacultad = (id, nombre) => {
  if (!boleta.facultad.includes(id)) {
    let tr = document.createElement("tr");
    tr.id = `ff${id}`;
    tr.innerHTML = `<td>${nombre}</td><td><button type="button" class="close" onclick="Quitar(${id},1)" >
                    <span aria-hidden="true">&times;</span>
                </button></td>`;
    tablafacultad.appendChild(tr);
    boleta.facultad.push(parseInt(id));
  } //valida que no se vuelva a repetir la facultad
  modalbuscar.modal("hide");
};

const AgregarCarrera = (id, nombre) => {
  if (!boleta.carrera.includes(id)) {
    let tr = document.createElement("tr");
    tr.id = `cc${id}`;
    tr.innerHTML = `<td>${nombre}</td><td><button type="button" class="close" onclick="Quitar(${id},2)" >
                    <span aria-hidden="true">&times;</span>
                </button></td>`;
    tablacarrera.appendChild(tr);
    boleta.carrera.push(parseInt(id));
  } //valida que no se vuelva a repetir la facultad
  modalbuscar.modal("hide");
};

const AgregarMateria = (id, nombre) => {
  if (!boleta.materia.includes(id)) {
    let tr = document.createElement("tr");
    tr.id = `mm${id}`;
    tr.innerHTML = `<td>${nombre}</td><td><button type="button" class="close" onclick="Quitar(${id},4)" >
                    <span aria-hidden="true">&times;</span>
                </button></td>`;
    tablamateria.appendChild(tr);
    boleta.materia.push(parseInt(id));
  } //valida que no se vuelva a repetir la facultad
  modalbuscar.modal("hide");
};

const getItemTablas = (id)=>{
  let tabla = document.getElementById(id);
  console.log(tabla);
  /*for( let i=0,cell;cell=tabla.cells[i];i++){
      console.log(cell);
  }*/
}

const InformeBoleta = (boleta, codigo = "CJ01") => {
  const informe = new  jsPDF('p', 'mm', 'letter');
  //32*36
  getItemTablas('tfacultad');
  let m=document.getElementById("univo-logo").src;
  let img = new Image();
  img.src=m;
  informe.addImage(img,'jpg',10,15,15,15);
  informe.setFont("normal");
  informe.setFontSize(16);
  informe.setFontType("bold");
  informe.text("HOJA DE MATERIALES", 60, 15,);
  informe.setFontSize(12);
  informe.setFontType("bold");
  
  informe.text("CODIGO",8, 25);
  informe.setFontType("normal");
  informe.setFontSize(12);
  informe.text(codigo, 8, 36);
  informe.setFontType("bold");
  informe.setFontSize(12);
  informe.text("ENCARGADO", 65, 25);
  informe.setFontType("normal");
  informe.setFontSize(12);
  informe.text(boleta.encargado.trim(), 50, 36);
  informe.autoTable({
    html:"#tfacultad",
    margin:{top:50,}
  });
  informe.save(`Boleta_${codigo}.pdf`);
};

const CrearBoleta = async () => {
  try {
    let validacion = validacionDatos();
    if (validacion.validation) {
        //InformeBoleta(validacion.boleta)
      const headers = new Headers();
      headers.append("Content-Type", "application/json utf-8");
      const request = await fetch("/Boleta/create", {
        method: "POST",
        headers: headers,
        body: JSON.stringify(validacion.boleta),
      });

      if (request.ok) {
        let data = await request.json();
        console.log(data);
        if (data.hasOwnProperty("key")) {
          let codigo = data.key.trim();
          console.log(data);
          listarBoletas();
          modalboleta.modal('hide');
          Swal.fire({
            icon:'success',
            title:'Exito',
            text:'Boleta Guardada',
            timer:2000
          });
          clean();
        } else {
          Swal.fire({
            icon: "error",
            title: "Advertencia",
            text: data.message,
          });
        }
      } else {
        let data = await request.text();
        let menssage_error =
          "Ocurrio un error desconocido al crear la solicitud";
        if (isJSON(data)) {
          let error = JSON.parse(data);
          if (error.hasOwnProperty("message")) {
            menssage_error = error.message;
          }
        }
        Swal.fire({
          icon: "error",
          title: "Advertencia",
          text: menssage_error,
        });
      }
    } else {
      Swal.fire({
        icon: "warning",
        title: "Advertencia",
        text: "Te Faltan campos por llenar",
      });
    }
  } catch (error) {
    console.log(error);
    Swal.fire({
      icon: "error",
      title: "Advertencia",
      text: "Error al procesar la solicitud",
    });
  }
}; //crea la boleta

const listarFacultades = async () => {
      const encabezado = document.getElementById("mencabezado");
      let tabla = document.getElementById("detalletbl");
      encabezado.innerHTML = `<th>Nombre de Facultad</th>`;
      let html = "";
      Inventario.facultad.forEach((e) => {
        html += `<tr onclick="AgregarFacultad(${e.id},'${e.nombre}')"><td>${e.nombre}</td></tr>`;
      });
      tabla.innerHTML = html;
      modalbuscar.modal("show");
   
};

const listarCarreras = async () => {
  const encabezado = document.getElementById("mencabezado");
  let tabla = document.getElementById("detalletbl");
  encabezado.innerHTML = `<th>Nombre de Carrera</th>`;
  let html = "";
  Inventario.carreras.forEach((e) => {
    html += `<tr onclick="AgregarCarrera(${e.id},'${e.carrera}')"><td>${e.carrera}</td></tr>`;
  });
  tabla.innerHTML = html;
  modalbuscar.modal("show");
   
};

const listarMaterias = async () => {
 
  const encabezado = document.getElementById("mencabezado");
  let tabla = document.getElementById("detalletbl");
  encabezado.innerHTML = `<th>Nombre de Materia</th>`;
  let html = "";
  Inventario.materias.forEach((e) => {
    html += `<tr onclick="AgregarMateria(${e.id},'${e.materia}')"><td>${e.materia}</td></tr>`;
  });
  tabla.innerHTML = html;
  modalbuscar.modal("show");
  
};

const listarInventario = async () => {
  try {
    const request = await fetch("/Producto/list");
    switch (request.status) {
      case 200: {
        let response = await request.json();
        response.value.forEach((i) => {
          let tr = document.createElement("tr");
          tr.onclick = (prevent) => {
            prevent.preventDefault();
            materialAdd(i.id, i.codigo, i.nombre,Number(i.existencia));
          };
          tr.innerHTML = `<td>${i.codigo}</td>
                    <td>${i.nombre}</td>
                    <td>${i.existencia}</td>`;
          tablaInventario.appendChild(tr);
        });
        break;
      }
      default: {
        Swal.fire({
          icon: "warning",
          title: "Advertencia",
          text: "Error al obtener el inventario",
        });
      }
    }
  } catch (error) {
    console.log(error);
  }
};

const funciones = () => {
  btnuevo.onclick = () => {
    clean();
    $("#modal").modal("show");
  };

  btnaddfacultad.onclick = () => {
    listarFacultades();
  };

  btnaddcarrera.onclick = () => {
    listarCarreras();
  };

  btnmateriadd.onclick = () => {
    listarMaterias();
  };

  btnInventario.onclick = () => {
    modalInventario.modal("show");
  };

  btnCrearBoleta.onclick = () => {
    CrearBoleta();
  };
};

const getMaterias = async ()=>{
  try {
    const request = await fetch("/Materia/list");
    if (request.status === 200) {
      const response = await request.json();
      Inventario.materias = response.value.map(m=>{
        return {
          id:m.id,
          materia:m.materia.trim()
        };
      });
      
    } else {
      throw "Ocurrio un erro al obtener las Materias";
    }
  } catch (e) {
    console.log(e);
  }
}//obtiene el listado de materias del server
const getFacultades = async () =>{
  try {
    const request = await fetch("/Boleta/listarFacultades");
    if (request.status === 200) {
      const response = await request.json();
      Inventario.facultad = response.value.map(f=>{
        return{
          id:f.id,
          nombre:f.nombre.trim()
        }
      })
    } else {
      throw "Ocurrio un erro al obtener las facultades";
    }
  } catch (e) {
    console.log(e);
  }
}//obtiene el listado de facultades del server

const getCarreras = async () =>{
  try {
    const request = await fetch("/Boleta/listarCarreras");
    if (request.status === 200) {
      const response = await request.json();
      console.log(response.value);
      Inventario.carreras = response.value.map(c=>{
        return {
          id:c.id,
          carrera:c.carrerra.trim()
        }
      });
    } else {
      throw "Ocurrio un error al obtener las facultades";
    }
  } catch (e) {
    console.log(e);
  }
}//obtiene el listado de carreras del server

const eliminar = async (id)=>{
  try {
    const request = await fetch(`/Boleta/delete?idboleta=${id}`,{
      method:'DELETE'
    });

    if(request.ok){
      listarBoletas();
      Swal.fire({
        icon:'success',
        title:'Exito',
        text:'La boleta ha sido eliminada',
        timer:2000
      });
    }else{
      let data = await request.text();
      if(isJSON(data)){
        let msn= JSON.parse(data);
        Swal.fire({
          icon:'warning',
          title:'Advertencia',
          text:msn.value.message,
          timer:2000
        })
      }else{
        
        Swal.fire({
          icon:'warning',
          title:'Advertencia',
          text:'ALgo al ocurrido al eliminar la boleta, intenta nuevamente',
          timer:2000
        })
      }
    }

    
  } catch (error) {
    Swal.fire({
      icon:'error',
      title:'advertencia',
      text:error
    })
  }
}


const alertaDelete = (id,codigo)=>{
  Swal.fire({
    icon:'warning',
    title:'Advertencia',
    text:`Estas seguro de querer eliminar la boleta ${codigo}, una vez hecho los cambios
    no se podra volver al estado anterior`,
    showCloseButton: true,
    showCancelButton: true,
    confirmButtonText: `Eliminar`,
    cancelButtonText:'Cancelar'
  }).then(result=>{
    if(result.isConfirmed){
        eliminar(id);
    }
  })
}

$(document).ready((e) => {
  listarBoletas();
  listarInventario();
  getMaterias();
  getFacultades();
  getCarreras();
  funciones();
});
