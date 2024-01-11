window.onload=inicializaEventos

function inicializaEventos() {
    document.getElementById("btnGuardar").addEventListener("click", guardarPersona, false)
}

function guardarPersona() {

    nombre= document.getElementById("nombrePersona").value
    apellidos=document.getElementById("apellidosPersona").value

   //instancio un objeto Persona.
   var p = new Persona(nombre, apellidos);

   alert(p.nombre+""+ p.apellidos)
}

class Persona {
    constructor (nombre, apellidos) {
       this.nombre=nombre;
       this.apellidos=apellidos;
   }   
}


