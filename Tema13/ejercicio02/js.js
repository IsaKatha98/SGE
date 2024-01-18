window.onload= inicializa;

function inicializa() {

    let button= document.getElementById("btnSaludar");

    button.addEventListener("click", saludar, false);


}

function saludar() {

    //alert("hola"); esto funciona

    let miLLamada= new XMLHttpRequest();
    let divMensaje= document.getElementById("mensaje");

    miLLamada.open("GET", "https://crudnervion.azurewebsites.net/api/personas");

    miLLamada.onreadystatechange= function() {

        if (miLLamada.readyState<4) {

            divMensaje.innerHTML="Cargando..."
            
        } else  if (miLLamada.readyState==4&& miLLamada.status==200) {
                
                let response = JSON.parse(miLLamada.responseText);
                divMensaje.innerHTML= response[0].nombre+" "+response[0].apellidos;
               
            
        
        }
    };

    

    miLLamada.send();

}
