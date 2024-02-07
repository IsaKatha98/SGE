window.onload=inicializa; //no podemos llamar a la función directamente porque se ejectuaría

var divMensaje;
var listaDepartamentos=[];

function pedirDatos() {

    alert("hola"); //esto funciona

    let miLLamada= new XMLHttpRequest();
    
    miLLamada.open("GET", "https://crudisasegundo.azurewebsites.net/api/personas");

    //definimos los estados
    miLLamada.onreadystatechange= function() {

        if (miLLamada.readyState<4) {

            
            
        } else  if (miLLamada.readyState==4&& miLLamada.status==200) {
                
                let response = JSON.parse(miLLamada.responseText);
                
        }
    };

    

    miLLamada.send();

}
