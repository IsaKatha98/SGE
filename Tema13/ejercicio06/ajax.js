window.onload=inicializa; //no podemos llamar a la función directamente porque se ejectuaría

var listaMarcas=document.getElementById("marca")
var button= document.getElementById("btnGuardar");
var listaModelos=[]

//declaramos el div.
var divModelos=document.getElementById("divModelos");


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
                    var marca= data[i];
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
    var idMarca=listaMarcas.value;

    alert("pedimos los modelos:"+marca); //esto funciona

    let getModelos= new XMLHttpRequest();
    
    getModelos.open("GET", "https://ajaxej6.azurewebsites.net/api/modelos/byMarca/"+idMarca);

    //definimos los estados
    getModelos.onreadystatechange= function() {

        if (getModelos.readyState<4) {
   
            
        } else  if (getModelos.readyState==4&& getModelos.status==200) {
                
                //Técnicamente, aquí hay que rellenar el listado y la vista.
                //parseamos la respuesta json
                listaModelos=JSON.parse(getModelos.responseText);

               crearSelectModelos ()
                
        }

    };

    getModelos.send();

}


function crearSelectModelos() {

     //primero tenemos que borrar todos los hijos del div.
     divModelos.innerHTML="" 

    //creamos un elemento h2 que será un título.
    var titulo=document.createElement('h2');
    titulo.textContent="Modelos";
    divModelos.appendChild(titulo)

   //ahora tenemos que filtrar listaModelos por el id de la marca seleccionada.
   //ese id está guardado en el option
   for (var i=0; i<listaModelos.length;i++) {

    
    var modelo=listaModelos[i];
    

        //pintamos el label y el input de cada modelo.
        var modeloNombre= document.createElement('label')
        var modeloPrecio= document.createElement('input')

       
        //creamos un salto de línea
        // Crea un elemento <br> para representar un salto de línea
        var saltoDeLinea = document.createElement('br');

        //damos valor a los elementos.
        modeloNombre.textContent=modelo.nombre;
        modeloPrecio.value=modelo.precio;
        modeloPrecio.id=modelo.idModelo;
        modeloPrecio.name='precioDelModelo';
        

        //añadimos los elementos al div
        divModelos.appendChild(modeloNombre);
        divModelos.appendChild(modeloPrecio);
        divModelos.appendChild(saltoDeLinea);

        

   }
}

function guardarCambios() {

   var modelosModificado= divModelos.querySelectorAll('[name="precioDelModelo"]')

   for (var i=0;i<modelosModificado.length;i++) {

        if (modelosModificado[i].value!=listaModelos[i].precio) {
            //Tenias puesto modeloModificado[i].modelo.precio
            //modeloModificado[i] ya es un modelo

            //En vez de hacer un Put por cada uno que sea diferente
            //mira a ver si lo puedes meter en un array (modificarArray)
            //y haces put de eso

            var modificarPrecio= new XMLHttpRequest();

            modificarPrecio.open("PUT","https://ajaxej6.azurewebsites.net/api/modelos/"+modelosModificado[i].id);

            modificarPrecio.setRequestHeader('Content-type', 'application/json; charset=utf-8');

            //Machacamos el precio del modelo que queremos enviar.
            listaModelos[i].precio=modelosModificado[i].value
            

            var json=JSON.stringify(listaModelos[i]);

                modificarPrecio.onreadystatechange=function() {

                    if(modificarPrecio.readyState<4) {

                    } else if (modificarPrecio.readyState == 4 && modificarPrecio.status == 200) {
                    
                        alert("Precio modificado");

                    }

                    //Tienes que borrar los modelos anteriores q se t lia
                    //Prueba a seleccionar todas las marcas y vas a ver como se apilan
                    //T recomiendo crear un div en el html y ponerle un id
                    //Cada vez q se seleccione una marca, se borra el contenido del div y se crea uno nuevo
                    //Lo tienes casi hecho
                    //Animo Animo :D
                


            };


        
        modificarPrecio.send(json);

    }

     //comparar si son distintos a los precios que ya existían en la api.

    //mandar los elementos modificados.
}
}
