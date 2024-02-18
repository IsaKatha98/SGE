window.onload=first; //no podemos llamar a la función directamente porque se ejectuaría

var tablePeople=document.getElementById("maintable")
var buttonNew= document.getElementById("btnNew");
var buttonEdit= document.getElementById("btnEdit");
var buttonDelete= document.getElementById("btnDelete");
var rowsPeople= document.getElementById("rows"); //tbody
var newRow=document.getElementsByTagName("tr");

function first() {

    getsIndex()
    //each row of the table can be clicked
  
    rowsPeople.addEventListener("click", selected, false);
    //edite and delete buttons will be hidden
    //these buttons will only show when a person is selected
    buttonDelete.style.display="none";
    buttonEdit.style.display="none";
    
}


function getsIndex () {

    var url="https://crudisasegundo.azurewebsites.net/api/personas";
    
    //we fetch the url
    fetch(url)
    .then(response=>{
        
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
        for (var i=0; i<data.length;i++) {

            //creates a person
            var person= data[i];
            //creates a row for every person in the list.
            var newRow=rowsPeople.insertRow();

            //creates a cell for every property a person has.
            var cellName=newRow.insertCell(0);
            var cellSurname=newRow.insertCell(1);
            var cellAddress=newRow.insertCell(2);
            var cellPhone= newRow.insertCell(3);
            var cellPic= newRow.insertCell(4);
            var cellBirthDate= newRow.insertCell(5);
            var cellDept=newRow.insertCell(6);

            //adds value to each cell.
            cellName.innerHTML=person.nombre;
            cellSurname.innerHTML=person.apellidos;
            cellAddress.innerHTML=person.direccion;
            cellPhone.innerHTML=person.tlf;
            cellPic.innerHTML=person.fotoURL;
            cellBirthDate.innerHTML=person.fechaNac;
            cellDept.innerHTML=person.idDepartamento;
        }
        
    })
    
    //if there are errors.
    .catch(error=>{


    })

}



function selected() {

    //gets the selected person.
    alert("Se ha seleccionado una persona")

}