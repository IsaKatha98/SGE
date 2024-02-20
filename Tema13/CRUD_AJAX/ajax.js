
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

let beforeRow;


function first() {

    //load the list of departments
    //we make a promise that there is going to be a list of departments.
    getsDeptList()
    .then(()=>{
        getsIndex();

        rowsPeople.addEventListener("click", (selected)=>{
            const row= selected.target.closest("tr");

            //shows the buttons
            buttonEdit.style.visibility="visible";
            buttonDelete.style.visibility="visible";
           

            if (row){
                if (beforeRow){

                    beforeRow.style.backgroundColor="";
                }

                beforeRow=row;
                row.style.backgroundColor="#CBC8C8";
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

function selected(oPersona) {

    //saves the selected person.
 
    //gets the selected person.
    alert("Se ha seleccionado una persona:", oPersona);

}