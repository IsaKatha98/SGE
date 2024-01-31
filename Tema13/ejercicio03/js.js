function pedirDatos() {

    alert("hola"); //esto funciona

    let miLLamada= new XMLHttpRequest();
    

    miLLamada.open("GET", "https://crudnervion.azurewebsites.net/api/personas");

    //definimos los estados
    miLLamada.onreadystatechange= function() {

        if (miLLamada.readyState<4) {

            
            
        } else  if (miLLamada.readyState==4&& miLLamada.status==200) {
                
                let response = JSON.parse(miLLamada.responseText);
                
        }
    };

    

    miLLamada.send();

}
