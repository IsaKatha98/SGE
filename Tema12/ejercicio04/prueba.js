var tabla;

//llama a la función inicializa al cargar la página.
window.onload=inicializa


//función que inicializa la tabla, esto vale para todo el documento.
function inicializa() {
    tabla=document.getElementById("tabla");
}

//Función que recorre las celdas de una fila y devuelve un alert
//con cada celda.
function recorreCeldas() {

    var mensaje;
    for (var i=0; i<tabla.rows.length; i++) {
        for (var j=0; j< tabla.rows[i].length; j++) {
            mensaje=mensaje+" "+tabla.rows[i].cells[j].innerHTML;

        }

        mensaje= mensaje+"\n";
    }

    alert(mensaje);
}

//Función que agrega una fila.
function agregaFilas() {
    //inserta una fila del tamaño de las filas de la tabla
    var fila= tabla.insertRow(tabla.rows.length); 
    //recorremos una fila según el número de celdas que hay en un fila.
    for (var i=0; i<tabla.rows[i].cells.length; i++) {
        //añadimos una celda en la posición en la que estamos.
        fila.insertCell(i).innerHTML="Celda"+ tabla.rows.length +(i+1);
    }

}

//Función que borra la última fila.
function borraFilas() {
   
    tabla.deleteRow(tabla.rows.length-1);
}
