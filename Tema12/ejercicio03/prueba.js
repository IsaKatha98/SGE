function actualizarModelos() {
    var marca=document.getElementById("marca").value;
    var modelos=document.getElementById("modelo");

  //Elimina opciones anteriores.
  while (modelos.options.length>1){
    modelos.remove(1);
}


    //Agrega las opciones según la marca seleccionada.
    switch(marca) {
        case "toyota":
            modelos.add(new Option("Camry","camry"));
            modelos.add(new Option("Corolla","corolla"));
            modelos.add(new Option("RAV4","rav4"));
            break;

        case "honda":
            modelos.add(new Option("Civic","civic"));
            modelos.add(new Option("Accord","accord"));
            modelos.add(new Option("CR-4","cr-4"));
            break;

        case "ford":
            modelos.add(new Option("Focus","focus"));
            modelos.add(new Option("Fiesta","fiesta"));
            modelos.add(new Option("Fusion","fusion"));
            break;
    }

}  
