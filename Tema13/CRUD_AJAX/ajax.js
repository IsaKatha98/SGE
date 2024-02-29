
//classes
class Persona{
    constructor (id, nombre, apellidos, direccion, telefono, foto, fechaNac, idDepartamento) {
        this.id=id;
        this.nombre=nombre;
        this.apellidos=apellidos;
        this.direccion=direccion;
        this.telefono=telefono;
        this.foto=foto;
        this.fechaNac=fechaNac;
        this.idDepartamento=idDepartamento;
    }
}

class Departamento {
    constructor (id, nombre) {
        this.id=id;
        this.nombre=nombre;
    }
}

class PersonaconnombreDepartamento extends Persona{
    constructor (id, nombre, apellidos, direccion, telefono, foto, fechaNac, idDepartamento) {
        let nombreDepartamento="Departamento no asignado";
        super(id, nombre, apellidos, direccion, telefono, foto, fechaNac, idDepartamento);
        for (var i=0; i<listDept.length;i++) {

            if (idDepartamento==listDept[i].id) {
                
                nombreDepartamento=listDept[i].nombre;
                break;
            }
        }

        this.nombreDepartamento=nombreDepartamento;
              
    } 

}

window.onload=first;
 //gets all the elements from the document
var tablePeople=document.getElementById("maintable")
var btnNew=document.getElementById("btnNew");
var rowsPeople= document.getElementById("rows"); //tbody

var listDept=[] //variable that saves a list of departments
var listPeople=[];//variable that saves a list oof people and the name of their department

let beforeRow;

 //gets all the elements from the modal
 var inputName=document.getElementById("inputName");
 var inputSurname=document.getElementById("inputSurname");
 var inputAddress=document.getElementById("inputAddress");
 var inputPhoneNumber=document.getElementById("inputPhoneNumber");
 var inputPic=document.getElementById("inputPic");
 var inputBirthday=document.getElementById("inputBirthday");
 var selectDepartment=document.getElementById("selectDepartment"); //this is a select
 var optionSelected=document.getElementById("optionNameDept")
 var divGif=document.createElement("div");
 var btnDelete= document.getElementById("btnDelete");
 
 //connections to the API
 var urlConn="https://crudnervion.azurewebsites.net/api/personas/";
 var urlConnDept = "https://crudnervion.azurewebsites.net/api/departamentos/";


//gets the div that's going to be our modal.
var modalEdit=document.getElementById("modalEdit");

//gets the span element that closes the modal.
var span=document.getElementsByClassName("close")[0];

//get btnSave
var btnSave=document.getElementById("btnSave");

 //we fill the select with al the options possible.
 var selectDeptFilter=document.getElementById("filter");

/*Function that loads everything.
First, it will get the list of departments.
When it's sure this list exists, it will get the list of people.
Then it will load the filter, and the buttons.

TODO: btnNew doesn't work, it only reloads the page but I don't see why.
 */
function first() {

    //loads the list of departments
    //we make a promise that there is going to be a list of departments.
    getsDeptList()
    .then(()=>{
        getsIndex();

        //for selectDeptFilter, we need options from a list
        for (var i=0; i<listDept.length; i++) {
        
            let option= document.createElement('option');
            option.value=listDept[i].id;
            option.text=listDept[i].nombre;
            selectDeptFilter.appendChild(option);
        }

        //when the filter is changed, it will call its function.
        selectDeptFilter.onchange=function(){
            
            var selectedDeptByFilter= document.getElementById("filter").value;
            filter(selectedDeptByFilter);

        }

    })

    .catch(error=>{
        alert("Error fetching department list:", error);
    }) 

    
          //if the button is clicked, it should open the modal to insert a new person.
          btnNew.addEventListener("click", openModal(), false );

           //highlights the row in grey when the mouse is over the row
    rowsPeople.addEventListener("mouseover", function (event) {
        const row = event.target.closest("tr");

        if (row && !row.classList.contains("selected")) {
            
            row.style.backgroundColor = "#E0E0E0";
        }
    });

    //when the mouse is out the original color of the row is restored.
    rowsPeople.addEventListener("mouseout", function (event) {
        const row = event.target.closest("tr");

        if (row && !row.classList.contains("selected")) {
    
            row.style.backgroundColor = "";
        }
    });
  
    /*this adds an event listener to each row of the table,
    that allows to edit or to delete that person*/
    rowsPeople.addEventListener("click", (selected)=>{
        const row= selected.target.closest("tr");

        //gets the person from the list that matches ther row's id.
        for (var i=0;i<listPeople.length;i++) {
            
            if (row.id==listPeople[i].id) {

                //when it finds the person.
                //calls the edit function and sends the data in the row.
                edit(listPeople[i]);

            }
        }
    }, false);
}

/**
 *gets the list of people from the API 
 */
function getsIndex () {

    //we fetch the url
    fetch(urlConn)
    .then(response=>{
        //confirms thar response was a success
        if (!response.ok) {
            //if not, it throws an error
            alert("Not working");
        
        }

        return response.json();
    })
    //manages the data that comes from the API
    .then(data => {
    
        //goes through the list of people
        for (var i=0; i<data.length;i++) {

            //creates a person
            var oPersona= new PersonaconnombreDepartamento(data[i].id, data[i].nombre, data[i].apellidos, data[i].direccion, data[i].telefono, data[i].foto, data[i].fechaNac, data[i].idDepartamento)
             
            //we add this object to listPeople.
            listPeople.push(oPersona);

        }       

        //calls the function that's painting the table and sends it the list of People
        paintsTable(listPeople);
    })
    
    //if there are errors.
    .catch(error=>{
        alert("Not working", error);
    })

}

/**
 * Function that's going to transform each date into the format we wish.
 * @param {*} birthday 
 * @returns a date
 */
function formatDate(birthday){

    const date = new Date(birthday);
    
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2); // Agrega un 0 delante si es necesario
    const day = ('0' + date.getDate()).slice(-2); // Agrega un 0 delante si es necesario

    return `${year}-${month}-${day}`;
}

/**
 * Function that gets the list of Departments from the API.
 * @returns a list of departments
 */
function getsDeptList () {
    return new Promise(function(resolve, reject){

        //we fetch the url
        fetch(urlConnDept)
        .then(response=>{
            
            //confirm thar response was a success
            if (!response.ok) {
                //if not, it throws an error
                alert("Not working");
            
            }
    
            return response.json();
        })
        //manage the data that comes from the API
        .then(data => {
   
            //resolves promise
            listDept=data.map(dept => new Departamento(dept.id, dept.nombre));
            resolve();
        })
        
        //if there are errors.
        .catch(error=>{

            //rejects promise because of error
            reject(error)

        })

    })
   
}

/**
 * Function that paints the table the user will see.
 * @param {*} listPeople 
 */
function paintsTable (listPeople){

    rowsPeople.innerHTML="";


    listPeople.forEach(function(oPersona){

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
         cellPhone.innerHTML=oPersona.telefono;
         //we get the src of img.
         img.src=oPersona.foto;
         //we append the pic as a child of cellPic.
         cellPic.appendChild(img);
         //remember to format the date.
         cellBirthDate.innerHTML=formatDate(oPersona.fechaNac);
         cellDept.innerHTML=oPersona.nombreDepartamento;
    })

}

/**
 * Function that opens the modal to insert a new Person.
 */
function openModal() {

      //opens the modal.
      modalEdit.style.display="block";

      var title=document.getElementById("title");

      title.innerHTML="Insertar";

      //for selectDepartment, we need options from a list
      for (var i=0; i<listDept.length; i++) {
      
          let option= document.createElement('option');
          option.value=listDept[i].id;
          option.text=listDept[i].nombre;
          selectDepartment.appendChild(option);

      }

       //calls function saveChanges when btn clicked
      btnSave.onclick= function(){ 
          saveInsert();
      };

    // When the user clicks on <span> (x), close the modal
    span.onclick = function() {
        modalEdit.style.display = "none";
    }
}

/**
 * Function that makes a post request to the API.
 */
function saveInsert() {

    //we get an array of inputs from one specific row.
    var arrayInput= modalEdit.querySelectorAll('[name=edit]');

    //TODO: hay problemas en recoger el idDepartamento.
    //build an object Persona
    var personNew= new Persona(0, arrayInput[0].value, arrayInput[1].value, arrayInput[2].value,  arrayInput[3].value, arrayInput[4].value, arrayInput[5].value, 100 );
    
    var postRequest= new XMLHttpRequest();
 
     postRequest.open("POST", urlConn);
     postRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
     var json=JSON.stringify(personNew);
 
     postRequest.onreadystatechange=function(){
 
         if(postRequest.readyState>4) {

            var gifImg= document.createElement("img");
            gifImg.src=""
            divGif.appendChild(gifImg);
            modalInsert.appendChild(divGif);
 
         } else if (postRequest.readyState==4&&postRequest.status==200) {
              
               alert("Persona creada con éxito")

               location.reload();
        }
     };
 
     postRequest.send(json);
    
}

/**
 * Function that opens the modal to edit a person when clicked on a row.
 * @param {*} oPersona 
 */
function edit(oPersona) {

    //opens the modal.
    modalEdit.style.display="block";
    btnDelete.style.display="block";

    var title=document.getElementById("title");

    title.innerHTML="Editar";
   
    //give them value.
    inputName.value=oPersona.nombre;
    inputSurname.value=oPersona.apellidos;
    inputAddress.value=oPersona.direccion;
    inputPic.value=oPersona.foto;
    inputPhoneNumber.value=oPersona.telefono;
    inputBirthday.value=formatDate(oPersona.fechaNac);
    optionSelected.value=oPersona.idDepartamento;
    optionSelected.text=oPersona.nombreDepartamento;

        //for selectDepartment, we need options from a list
        for (var i=0; i<listDept.length; i++) {
        
            if (listDept[i].id!=optionSelected.value) {
                let option= document.createElement('option');
                option.value=listDept[i].id;
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
        modalEdit.style.display = "none";
    }

    //when clicked, deletes this person.
  btnDelete.onclick=function(){
    deletePeople(oPersona);
  }
}

/**
 * Function that saves the changes that have been made on a person.
 * Makes a put request to the API.
 * @param {*} oPersona 
 */
function saveChanges(oPersona) {

    //we get an array of inputs from one specific row.
    var arrayInput= modalEdit.querySelectorAll('[name=edit]');

    //builds an object Persona
    var personModified= new Persona(oPersona.id, arrayInput[0].value, arrayInput[1].value, arrayInput[2].value,  arrayInput[3].value, arrayInput[4].value, arrayInput[5].value, arrayInput[6].value);

    var url=urlConn+oPersona.id;

    var modifyRequest= new XMLHttpRequest();

    //makes a put request to the API
    modifyRequest.open("PUT", url);
    modifyRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json=JSON.stringify(personModified);

    modifyRequest.onreadystatechange=function(){

        if(modifyRequest.readyState>4) {

        } else if (modifyRequest.readyState==4&&modifyRequest.status==200) {
             alert("Persona modificada con éxito")
                //reloads page
                location.reload();
          }
    };

    modifyRequest.send(json);
}

/**
 * Function that confirms an delete request of a Person.
 * Is that confirmation is true, it will delete this person from API.
 * @param {*} oPersona 
 */
function deletePeople (oPersona) {

    var confirmDelete=confirm("¿Seguro que quiere borrar a esta persona?");

    if (confirmDelete){

        var url=urlConn+oPersona.id;

        var deleteRequest= new XMLHttpRequest();
    
        //makes a delete request to the API.
        deleteRequest.open("DELETE", url);
        deleteRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
        var json=JSON.stringify(oPersona);
    
        deleteRequest.onreadystatechange=function(){
    
            if(deleteRequest.readyState>4) {
    
            } else if (deleteRequest.readyState==4&&deleteRequest.status==200) {
                  //alerts of changes.
                  alert("Persona eliminada.")
                
                  //reloads page
                  location.reload();
            }
        };
    
        deleteRequest.send(json);

    }   
}

/**
 * Funcion that builds a list filtered by the selected department.
 * @param {*} selectedDeptByFilter 
 */
function filter(selectedDeptByFilter) {

    var listOfFilteredPeople;

    if(selectedDeptByFilter) {
        if(selectedDeptByFilter=="Todos") {
            listOfFilteredPeople=listPeople;
        } else{
            listOfFilteredPeople=listPeople.filter(function(persona) {
                return persona.idDepartamento==selectedDeptByFilter;
            });

        }
        
    } else {
        listOfFilteredPeople=listPeople;
    }

    //sends the list to the function that'll paint the table.
    paintsTable(listOfFilteredPeople)

}

