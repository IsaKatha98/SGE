
//classes
class Persona{
    constructor (id, nombre, apellidos, direccion, tlf, fotoURL, fechaNac, idDepartamento) {
        this.id=id;
        this.nombre=nombre;
        this.apellidos=apellidos;
        this.direccion=direccion;
        this.tlf=tlf;
        this.fotoURL=fotoURL;
        this.fechaNac=fechaNac;
        this.idDepartamento=idDepartamento;
    }
}

class Departamento {
    constructor (idDepartamento, nombre) {
        this.idDepartamento=idDepartamento;
        this.nombre=nombre;
    }
}

class PersonaconnombreDepartamento extends Persona{
    constructor (id, nombre, apellidos, direccion, tlf, fotoURL, fechaNac, idDepartamento) {
        let nombreDepartamento="Departamento no asignado";
        super(id, nombre, apellidos, direccion, tlf, fotoURL, fechaNac, idDepartamento);
        for (var i=0; i<listDept.length;i++) {

            if (idDepartamento==listDept[i].idDepartamento) {
                
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
var rowsPeople= document.getElementById("rows"); //tbody
var listDept=[] //variable that saves a list of departments
var listPeople=[];

let beforeRow;

 //get all the elements from the modal
 var inputName=document.getElementById("inputName");
 var inputSurname=document.getElementById("inputSurname");
 var inputAddress=document.getElementById("inputAddress");
 var inputPhoneNumber=document.getElementById("inputPhoneNumber");
 var inputPic=document.getElementById("inputPic");
 var inputBirthday=document.getElementById("inputBirthday");
 var selectDepartment=document.getElementById("selectDepartment"); //this is a select
 var optionSelected=document.getElementById("optionNameDept")

//gets the div that's going to be our modal.
var modal=document.getElementById("myModal");

//gets the span element that closes the modal.
var span=document.getElementsByClassName("close")[0];

//get btnSave
var btnSave=document.getElementById("btnSave");


function first() {

    //load the list of departments
    //we make a promise that there is going to be a list of departments.
    getsDeptList()
    .then(()=>{
        getsIndex();

        buttonNew.addEventListener("click", (insert)=>{
             //opens the modal.
            modal.style.display="block";

            //for selectDepartment, we need options from a list
            for (var i=0; i<listDept.length; i++) {
        
            
                let option= document.createElement('option');
                option.value=listDept[i].idDepartamento;
                option.text=listDept[i].nombre;
                selectDepartment.appendChild(option);

            }

             //calls function saveChanges when btn clicked
            btnSave.onclick= function(){

                
                saveInsert();
            };

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
    }, false);

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
            var oPersona= new PersonaconnombreDepartamento(data[i].id, data[i].nombre, data[i].apellidos, data[i].direccion, data[i].tlf, data[i].fotoURL, data[i].fechaNac, data[i].idDepartamento)
             
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

function saveInsert() {

    //we get an array of inputs from one specific row.
    var arrayInput= modal.querySelectorAll('[name=edit]');

    //TODO: hay problemas en recoger el idDepartamento.
    //build an object Persona
    var personNew= new Persona(0, arrayInput[0].value, arrayInput[1].value, arrayInput[2].value,  arrayInput[3].value, arrayInput[4].value, arrayInput[5].value, 2);


      //get the url
      var url="https://crudisasegundo.azurewebsites.net/api/personas"
    
     var postRequest= new XMLHttpRequest();
 
     postRequest.open("POST", url);
     postRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
     var json=JSON.stringify(personNew);
 
     postRequest.onreadystatechange=function(){
 
         if(postRequest.readyState>4) {
 
         } else if (postRequest.readyState==4&&postRequest.status==200) {
               //closes the modal
               var message= document.createElement('p');
               message.innerHTML="Persona insertada con éxito";
               modal.appendChild(message);
   
   
               //reloads page
         }
     };
 
     postRequest.send(json);
    
}

function edit(oPersona) {

    //opens the modal.
    modal.style.display="block";
   
    //give them value.
    inputName.value=oPersona.nombre;
    inputSurname.value=oPersona.apellidos;
    inputAddress.value=oPersona.direccion;
    inputPic.value=oPersona.fotoURL;
    inputPhoneNumber.value=oPersona.tlf;
    inputBirthday.value=oPersona.fechaNac;
    optionSelected.value=oPersona.idDepartamento;
    optionSelected.text=oPersona.nombreDepartamento;

        //for selectDepartment, we need options from a list
        for (var i=0; i<listDept.length; i++) {
        
            if (listDept[i].idDepartamento!=optionSelected.value) {
                let option= document.createElement('option');
                option.value=listDept[i].idDepartamento;
                option.text=listDept[i].nombre;
                selectDepartment.appendChild(option);

            }         
        }

    //calls function saveChanges when btn clicked
    btnSave.onclick=function(){
        saveChanges(oPersona);
    };

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

function saveChanges(oPersona) {

    //we get an array of inputs from one specific row.
    var arrayInput= modal.querySelectorAll('[name=edit]');

     //build an object Persona
     var personModified= new Persona(oPersona.id, arrayInput[0].value, arrayInput[1].value, arrayInput[2].value,  arrayInput[3].value, arrayInput[4].value, arrayInput[5].value, arrayInput[6].value);

    var url="https://crudisasegundo.azurewebsites.net/api/personas/"+oPersona.id;

    var modifyRequest= new XMLHttpRequest();

    modifyRequest.open("PUT", url);
    modifyRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json=JSON.stringify(personModified);

    modifyRequest.onreadystatechange=function(){

        if(modifyRequest.readyState>4) {

        } else if (modifyRequest.readyState==4&&modifyRequest.status==200) {
              //closes the modal
              var message= document.createElement('p');
              message.innerHTML="Persona modificada con éxito";
              modal.appendChild(message);
  
  
              //reloads page
        }
    };

    modifyRequest.send(json);
}

