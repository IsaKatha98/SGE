
//clases
class Persona {
    constructor(Id, Nombre, Apellidos, FechaNac, Direccion, Telefono, Foto, IdDepartamento) {

        this.Id = Id;
        this.Nombre = Nombre;
        this.Apellidos = Apellidos;
        this.FechaNac = FechaNac;
        this.Direccion = Direccion;
        this.Telefono = Telefono;
        this.Foto = Foto;
        this.IdDepartamento = IdDepartamento;
    }
}

class Departamento {
    constructor(Id, Nombre) {
        this.Id = Id;
        this.Nombre = Nombre;
    }
}

class PersonaconnombreDepartamento extends Persona {
    constructor(Id, Nombre, Apellidos, FechaNac, Direccion, Telefono, Foto, IdDepartamento) {

        let nombreDepartamento = "Departamento no asignado";
        super(Id, Nombre, Apellidos, FechaNac, Direccion, Telefono, Foto, IdDepartamento);

        for (var i = 0; i < listDept.length; i++) {

            if (super.IdDepartamento == listDept[i].IdDepartamento) {

                nombreDepartamento = listDept[i].Nombre;
                break;
            }
        }

        this.nombreDepartamento = nombreDepartamento;

    }

}

//cogemos los elementos necesarios del html o los crea
var body = document.getElementsByTagName("body");
var table = document.getElementById("tabla");

var listDept = [] 
var listPeople = [];

var check = document.createElement("input");
check.type = "checkbox";

var divPersona = document.createElement("div");

var isChecked = false;


//cargamos la primera función cuando se abra la ventana.
window.onload = inicializa;

//función que carga los listados y manda los checks de las personas
function inicializa() {

    var body = document.getElementsByTagName("body");
    var table = document.getElementById("tabla");

    //llamamos al listado de departamentos.
    getRequestDept().then(() => {

        //una vez que ha llegado, pedimos el listado de personas.
        getRequestPersonas()

        //en teoría, aquí iría un listener del check de cada fila
        //que llamaría a la función getDetails y le manda el id de la persona seleccionada.
        //Esto se haría buscando en la lista de 
    })
}

//función que llama la listado de departamentos con una promesa
function getRequestDept() {

    return new Promise(function (resolve, reject) {

        var url = "http://localhost:5264/api/departamentos";

        //hacemos un fecth a esa url.
        fetch(url)
            .then(response => {

                //cpnfirmamos que todo bien
                if (!response.ok) {
                    
                    alert("No funciona");

                }

                return response.json();
            })

            //sección que gestiona los datos que llegan del fetch
            .then(data => {

                //crea un objeto departamento por cada elemento de data.
                listDept = data.map(dept => new Departamento(dept.Id, dept.Nombre));
                resolve();
            })

            //si hay errores, rechazamos la promesa
            .catch(error => {

                reject(error)

            })

    })

}

//esta función hace el get del listado de personas y pinta 
//las filas de la tabla
function getRequestPersonas() {

    var url = "http://localhost:5264/api/personas";

    //hacemos un fetch con esa url
    fetch(url)
        .then(response => {

            //mientras el estado de la respuesta sea menor que 4, esperamos a que cargue
            if (response.readyState < 4) {
                var mensaje = document.createElement("p");
                mensaje.innerHTML = "Cargando...0";
                table.appendChild(mensaje);
            }

            //confirmamos que todo bien
            if (!response.ok) {
                alert("No funciona");

            }

            return response.json();
        })

        //gestionamos los datos
        .then(data => {
            
            //recorre la lista de personas
            for (var i = 0; i < data.length; i++) {

                //creamos una persona con el nombre del Departamento
                var oPersona = new PersonaconnombreDepartamento(data[i].id, data[i].nombre, data[i].apellidos, data[i].fechaNac, data[i].direccion, data[i].telefono, data[i].foto, data[i].idDepartamento)

                //creamos una fila nueva y la añadimos a la tabla.
                var newRow = document.getElementById("newRow");

                //Fernando, he intentado crearte la tabla y nada funciona.
                //Se supone que el fallo está aquí, pero lleva todo el examen dándome errores muy extraños
                //Que si la tabla no me la detectaba con el getElementById.
                //Digo bueno, me creo la tabla y le hago un appendChild al body y tampoco funciona.
                //Lo mismo me ha pasado con las filas.

                table.appendChild(newRow);
               

                //cada fila tendrá como id el id de la persona.
                //esto nos servirá para identificar que fila ha sido seleccionada
                newRow.id = oPersona.id;

                //creamos las celdas necesarias
                var cellName = newRow.insertCell(0);
                var cellSurname = newRow.insertCell(1);
                var cellCheck = newRow.insertCell(2);

                //Le damos valor a cada celda
                cellName.innerHTML = oPersona.nombre;
                cellSurname.innerHTML = oPersona.apellidos;
                cellCheck.appendChild(check);

                //añadimos la persona que venimos de crear a una lista.
                //esto nos servirá para no tener que estar pidiéndoselo a la api.
                listPeople.push(oPersona);

            }
        })

        //En caso de errores
        .catch(error => {
            alert("No se ha podido traer la lista de personas", error);
        })

}

//está función hace un get de los detalles de una persona y los pinta en pantalla
//recibe como parámetro el id de una Persona.
function getDetails(id) {

    //hacemos el request.
    var url = "http://localhost:5264/api/personas/" +id;

    //hacemos el get a esa persona
    fetch(url)
        .then(response => {

            if (response.readyState < 4) {
                var mensaje = document.createElement("p");
                mensaje.innerHTML = "Cargando...0";
                tbody.appendChild(mensaje);
            }

            //confirmamos que todo bien
            if (!response.ok) {
               
                alert("Algo ha fallado");

            }

            return response.json();
        })
        //gestionamos los datos
        .then(data => {

            //recorremos el array que nos llega.
            for (var i = 0; i < data.length; i++) {

                //llamamos a los elementos del html.
                var nombre = document.getElementById("labelNombre");
                var apellidos = document.getElementById("labelApellidos");
                var fotoContenedor = document.getElementById("divFoto");
                var nombreDept = document.getElementById("labelNombreDept");

                //les damos valor
                nombre = oPersona.nombre;
                apellidos = oPersona.apellidos;

                //creamos una imagen y la añadimos a su contenedor.
                var foto = document.createElement("img");
                foto.src = oPersona.foto;
                fotoContenedor.appendChild(foto);

                nombreDept = oPersona.nombreDepartamento;

            } 
        })

        //if there are errors.
        .catch(error => {
            alert("Not working", error);
        })



}
