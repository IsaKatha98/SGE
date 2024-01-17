window.onload=inicializaEventos

function inicializaEventos() {
    document.getElementById("btnCambiar").addEventListener("click", cambiarTitulo, false)
}

function cambiarTitulo() {

    misH2=document.getElementsByTagName("h2");
    misH2[0].innerHTML="Osasuna nunca se rinde";
    
    miBoton= document.getElementById("btnCambiar");

    miBoton.value= "Ya has cambiado";
    miBoton.disabled=true;

}
