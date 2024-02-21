
//classes
class Persona {
    constructor(id, nombre, apellidos, direccion, tlf, fotoURL, fechaNac, idDepartamento) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.direccion = direccion;
        this.tlf = tlf;
        this.fotoURL = fotoURL;
        this.fechaNac = fechaNac;
        this.idDepartamento = idDepartamento;
    }
}

window.onload = first;

var tablePeople = document.getElementById("maintable")
var buttonNew = document.getElementById("btnNew");
var rowsPeople = document.getElementById("rows"); //tbody
var listPeople = [];

let beforeRow;

//gets the div that's going to be our modal.
var modal = document.getElementById("myModal");

//gets the span element that closes the modal.
var span = document.getElementsByClassName("close")[0];

function first() {

    getsIndex();

    

}


function getsIndex() {

    var url = "http://localhost:5036/api/persona";

    //we fetch the url
    fetch(url)
        .then(response => {

            //confirm thar response was a success
            if (!response.ok) {
                //if not, it throws an error
                throw new Error("Not working");

            }

            return response.json();
        })
        //manage the data that comes from the API
        .then(data => {

            //goes through the list of people
            for (var i = 0; i < data.length; i++) {

                //creates a person
                var oPersona = new PersonaconnombreDepartamento(data[i].id, data[i].nombre, data[i].apellidos, data[i].direccion, data[i].tlf, data[i].fotoURL, data[i].fechaNac, data[i].idDepartamento)

                //creates a row for every person in the list.
                var newRow = rowsPeople.insertRow();

                //each row will have as it's own id the id of a Person.
                newRow.id = oPersona.id;


                //creates a cell for every property a person has.
                var cellName = newRow.insertCell(0);
                var cellSurname = newRow.insertCell(1);
                var cellAddress = newRow.insertCell(2);
                var cellPhone = newRow.insertCell(3);
                //this cell is going to be an img, so we need an element type img.
                var cellPic = newRow.insertCell(4);
                var img = document.createElement('img');
                img.width = 80;
                img.height = 80;
                var cellBirthDate = newRow.insertCell(5);

                //adds value to each cell.
                cellName.innerHTML = oPersona.nombre;
                cellSurname.innerHTML = oPersona.apellidos;
                cellAddress.innerHTML = oPersona.direccion;
                //we get the src of img.
                img.src = oPersona.fotoURL;
                //we append the pic as a child of cellPic.
                cellPic.appendChild(img);
                cellBirthDate.innerHTML = oPersona.fechaNac;

                //we add this object to listPeople.
                listPeople.push(oPersona);
            }
        })

        //if there are errors.
        .catch(error => {
            //throw new Error("Not working", error);
        })

}

function edit(oPersona) {

    //opens the modal.
    modal.style.display = "block";
    //get all the elements.
    var inputName = document.getElementById("inputName");
    var inputSurname = document.getElementById("inputSurname");
    var inputAddress = document.getElementById("inputAddress");
    var inputPhoneNumber = document.getElementById("inputPhoneNumber");
    var inputPic = document.getElementById("inputPic");
    var inputBirthday = document.getElementById("inputBirthday");

    //give them value.
    inputName.value = oPersona.nombre;
    inputSurname.value = oPersona.apellidos;
    inputAddress.value = oPersona.direccion;
    inputPic.value = oPersona.fotoURL;
    inputPhoneNumber.value = oPersona.tlf;
    inputBirthday.value = oPersona.fechaNac;

    //get btnSave
    var btnSave = document.getElementById("btnSave");

    //calls function saveChanges when btn clicked
    btnSave.onclick = function () {
        saveChanges(oPersona);
    };

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

}

function saveChanges(oPersona) {

    //we get an array of inputs from one specific row.
    var arrayInput = modal.querySelectorAll('[name=edit]');

    //cast oPersona to type Persona
    var personModified = new Persona(oPersona.id, arrayInput[0].value, arrayInput[1].value, arrayInput[2].value, arrayInput[3].value, arrayInput[4].value, arrayInput[5].value, arrayInput[6].value);

    var url = "http://localhost:5036/api/persona" + oPersona.id;

    var modifyRequest = new XMLHttpRequest();

    modifyRequest.open("PUT", url);
    modifyRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json = JSON.stringify(personModified);

    modifyRequest.onreadystatechange = function () {

        if (modifyRequest.readyState > 4) {

        } else if (modifyRequest.readyState == 4 && modifyRequest.status == 200) {
            //closes the modal
            var message = document.createElement('p');
            message.innerHTML = "Persona modificada con éxito";
            modal.appendChild(message);


            //reloads page
        }
    };

    modifyRequest.send(json);
}
