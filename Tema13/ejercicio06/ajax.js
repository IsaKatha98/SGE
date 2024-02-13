window.onload=inicializa; //no podemos llamar a la función directamente porque se ejectuaría

var listaMarcas=document.getElementById("marca")
let button= document.getElementById("btnGuardar");



function inicializa() {

    //llamamos a pedir marcas
    pedirMarcas()
    listaMarcas.addEventListener("change", pedirModelos, false) //cuando cambie la lista, pedimos los modelos
    button.addEventListener("click", guardarCambios, false);
}

function pedirMarcas() {

    alert("hola"); //esto funciona

    let miLLamada= new XMLHttpRequest();
    
    miLLamada.open("GET", "https://ajaxej6.azurewebsites.net/api/marcas");

    //definimos los estados
    miLLamada.onreadystatechange= function() {

        if (miLLamada.readyState<4) {
   
            
        } else  if (miLLamada.readyState==4&& miLLamada.status==200) {
                
                //Técnicamente, aquí hay que rellenar el listado y la vida.
                //parseamos la respuesta json
                let data=JSON.parse(miLLamada.responseText);

                //creamos un option de listaMarcas
                let opcion= document.createElement('option');
                opcion.value=null;
                opcion.text="--elige una marca--";
                listaMarcas.appendChild(opcion);

                //iteramos sobre los datos y agragamos las opciones de la lista.
                for (var i=0; i<data.length; i++){
                    
                    //asociamos la marca al data.
                    marca= data[i];
                    let opcion= document.createElement('option');// hay que crear un option por cada vuelta del for.
                    opcion.value=marca.idMarca; //asigna el valor de la marca
                    opcion.text= marca.nombre; //asigna el tecto de la marca
                    listaMarcas.appendChild(opcion); //agrega la opción a la lista.
                               
                };
        }
    };

    miLLamada.send();

}


function pedirModelos() {

    //guardamos la opción elegida en una variable
    var marca = listaMarcas.options[listaMarcas.selectedIndex].text;
    var idMarca=listaMarcas.options[listaMarcas.selectedIndex].value;

    alert("pedimos los modelos:"+marca); //esto funciona

    let getModelos= new XMLHttpRequest();
    
    getModelos.open("GET", "https://ajaxej6.azurewebsites.net/api/modelos");

    //definimos los estados
    getModelos.onreadystatechange= function() {

        if (getModelos.readyState<4) {
   
            
        } else  if (getModelos.readyState==4&& getModelos.status==200) {
                
                //Técnicamente, aquí hay que rellenar el listado y la vista.
                //parseamos la respuesta json
                let listaModelos=JSON.parse(getModelos.responseText);

                //creamos un elemento h2 que será un título.
                var titulo=document.createElement('h2');
                titulo.textContent="Modelos";
                document.body.appendChild(titulo)


               //ahora tenemos que filtrar listaModelos por el id de la marca seleccionada.
               //ese id está guardado en el option
               for (var i=0; i<listaModelos.length;i++) {

                var modelo=listaModelos[i];
                if (modelo.idMarca==idMarca){

                    //pintamos el label y el input de cada modelo.
                    var modeloNombre= document.createElement('label')
                    var modeloPrecio= document.createElement('input')

                   
                    //creamos un salto de línea
                    // Crea un elemento <br> para representar un salto de línea
                    var saltoDeLinea = document.createElement('br');

                    

                   
                    document.body.appendChild(modeloNombre);
                    document.body.appendChild(modeloPrecio);
                    document.body.appendChild(saltoDeLinea);

                    

                    modeloNombre.textContent=modelo.nombre;
                    modeloPrecio.value=modelo.precio;
                }


               }
        }
    };

    getModelos.send();

}

function guardarCambios() {

}
