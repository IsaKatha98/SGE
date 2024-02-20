
//classes
class Persona{

    constructor (p) {
        this.id=p.id;
        this.nombre=p.nombre;
        this.apellidos=p.apellidos;
        this.direccion=p.direccion;
        this.tlf=p.tlf;
        this.fotoURL=p.fotoURL;
        this.fechaNac=p.fechaNac;
        this.idDepartamento=p.idDepartamento;
    }
}

class Departamento {
    constructor (idDepartamento, nombre) {
        this.idDepartamento=idDepartamento;
        this.nombre=nombre;
    }
}

class PersonaconnombreDepartamento extends Persona{

    constructor(p){
        let nombreDepartamento="Departamento no asignado";
        super(p);
        for (var i=0; i<listDept.length;i++) {

            if (p.idDepartamento==listDept[i].idDepartamento) {
                
                nombreDepartamento=listDept[i].nombre;
                break;
            }
        }

        this.nombreDepartamento=nombreDepartamento;
        
        
    } 

}

window.onload=first;

var tablePeople=document.getElementById("maintable")
var buttonNew= document.getElementById("btnNew");
var buttonEdit= document.getElementById("btnEdit");
var buttonDelete= document.getElementById("btnDelete");
var rowsPeople= document.getElementById("rows"); //tbody
var listDept=[] //variable that saves a list of departments
var listPeople=[];

let beforeRow;

//gets the div that's going to be our modal.
var modal=document.getElementById("myModal");

//gets the span element that closes the modal.
var span=document.getElementsByClassName("close")[0];

function first() {

    //load the list of departments
    //we make a promise that there is going to be a list of departments.
    getsDeptList()
    .then(()=>{
        getsIndex();

        rowsPeople.addEventListener("click", (selected)=>{
            const row= selected.target.closest("tr");

            if (row){
                if (beforeRow){

                    beforeRow.style.backgroundColor="";
                }

                beforeRow=row;
                row.style.backgroundColor="#CBC8C8";
            }

            //get the person from the list that matches ther row's id.
            for (var i=0;i<listPeople.length;i++) {
                
                if (row.id==listPeople[i].id) {

                    //when it finds the person.
                    //calls the edit function and sends the data in the row.
                    edit(listPeople[i]);

                }
            }
        }, false);
    //edit and delete buttons will be hidden
    //these buttons will only show when a person is selected
    buttonDelete.style.visibility="hidden";
    buttonEdit.style.visibility="hidden";
    })

    .catch(error=>{
        console.error("Error fetching department list:", error);
    })
    
    
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
            var oPersona= new PersonaconnombreDepartamento(data[i])
             
            //creates a row for every person in the list.
            var newRow=rowsPeople.insertRow();

            //each row will have as it's own id the id of a Person.
            newRow.id=oPersona.id;

            //creates a cell for every property a person has.
            var cellName=newRow.insertCell(0);
            var cellSurname=newRow.insertCell(1);
            var cellAddress=newRow.insertCell(2);
            var cellPhone= newRow.insertCell(3);
            //this cell is going to be an img, so we need an element type img.
            var cellPic= newRow.insertCell(4);
            var img=document.createElement('img'); 
            img.width=80;
            img.height=80;
            var cellBirthDate= newRow.insertCell(5);
            var cellDept=newRow.insertCell(6);

            //adds value to each cell.
            cellName.innerHTML=oPersona.nombre;
            cellSurname.innerHTML=oPersona.apellidos;
            cellAddress.innerHTML=oPersona.direccion;
            cellPhone.innerHTML=oPersona.tlf;
            //we get the src of img.
            img.src=oPersona.fotoURL;
            //we append the pic as a child of cellPic.
            cellPic.appendChild(img);
            cellBirthDate.innerHTML=oPersona.fechaNac;
            cellDept.innerHTML=oPersona.nombreDepartamento;

            //we add this object to listPeople.
            listPeople.push(oPersona);

            
        }
    })
    
    //if there are errors.
    .catch(error=>{
        //throw new Error("Not working", error);
    })

}

function getsDeptList () {
    return new Promise(function(resolve, reject){

        var url="https://crudisasegundo.azurewebsites.net/api/departamentos";

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
   
            //resolves promise
            listDept=data.map(dept => new Departamento(dept.idDepartamento, dept.nombre));
            resolve();
        })
        
        //if there are errors.
        .catch(error=>{

            //rejects promise because of error
            reject(error)

        })

    })
   
}

function edit(oPersona) {

    //opens the modal.
    modal.style.display="block";

    //get all the elements.
    var inputName=document.getElementById("inputName");
    var inputSurname=document.getElementById("inputSurname");
    var inputAddress=document.getElementById("inputAddress");
    var inputPhoneNumber=document.getElementById("inputPhoneNumber");
    var inputPic=document.getElementById("inputPic");
    var inputBirthday=document.getElementById("inputBirthday");
    var inputDepartment=document.getElementById("inputDepartment");

    //give them value.
    inputName.value=oPersona.nombre;
    inputSurname.value=oPersona.apellidos;
    inputAddress.value=oPersona.direccion;
    inputPic.value=oPersona.fotoURL;
    inputPhoneNumber.value=oPersona.tlf;
    inputBirthday.value=oPersona.fechaNac;
    inputDepartment.value=oPersona.nombreDepartamento;

    //get btnSave
    var btnSave=document.getElementById("btnSave");

    //calls function saveChanges when btn clicked
    btnSave.onclick=saveChanges();

    // When the user clicks on <span> (x), close the modal
    span.onclick = function() {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function(event) {
        if (event.target == modal) {
        modal.style.display = "none";
        }
  }

}

function saveChanges() {
    
}