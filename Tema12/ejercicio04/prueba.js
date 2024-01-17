var tabla;//declaramos tabla como una variabele global

//llama a la función inicializa al cargar la página.
window.onload=inicializa

//función que inicializa la tabla, esto vale para todo el documento.
function inicializa() {
    tabla=document.getElementById("tabla")
}

function cambiarTitulo() {

    misH2=document.getElementsByTagName("h2");
    alert ("El array"+misH2);
    alert("La primera posicion del array"+misH2[0]);
    misH2[0].innerHTML="Osasuna nunca se rinde";

    for (i=0; i<misH2.length;i++) {

        misH2[i].innerHTML="Migue Pelate"
    }
    
    miBoton= document.getElementById("btnCambiar");

    miBoton.value= "Ya has cambiado";
    miBoton.disabled=true;

}
