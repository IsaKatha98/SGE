using Ejercicio03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Biblioteca;
using DAL.Manejadoras;
using DAL.Listados;
using Ejercicio03.Models.ViewModels;

namespace Ejercicio03.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Hay que pasale al VM una lista de personas y el objeto clsPersona.
            List<clsPersona> listadoPersonas = clsListadoPersonas.getListadoPersonas();
            clsPersona persona = new clsPersona();
            //string nombreDepartamento = clsDepartamento.Nombre;
            
            clsListadoPersonasVM vistaVM = new clsListadoPersonasVM(listadoPersonas, persona);

            return View(vistaVM);
        }

        public IActionResult Details(int id) {

            //Quí técnicamente le tenemos que pasar la función readDetailsPersona de la clase DAL.
            //Nos devuelve un int.
            //Instanciamos un objeto de la clsManejadora para luego poder llamar a la función.
            clsManejadoraPersonaDAL handler= new clsManejadoraPersonaDAL();

            //guardamos en una variable clsPersona el resultado de la función que lee los detalles de la persona.
            clsPersona persona= handler.readDetailsPersonaDAL(id);
            

            //Ahora hacemos un if-else.
            if (persona==null)
            {
                throw new Exception();
            
            } else
            {
                //Instanciamos el modelo que le pasaremos a la vista.
                clsDetallesVM vistaDetails = new clsDetallesVM(persona);
                return View(vistaDetails);
            }
        
        }

        public ActionResult Edit (int id)
        {
           
            //Instanciamos la vista.
            clsEditVM vistaEditVM = new clsEditVM();
            
            return View(vistaEditVM);
        }

        [HttpPost]
        public ActionResult Edit (int id, int idDepartamento) 
        {
            //AQuí técnicamente le tenemos que pasar la función readDetailsPersona de la clase DAL.
            //Nos devuelve un int.
            //Instanciamos un objeto de la clsManejadora para luego poder llamar a la función.
            clsManejadoraPersonaDAL handler = new clsManejadoraPersonaDAL();
            int numFilasAfectadas = handler.updatePersonaDAL(id, idDepartamento);

            //Ahora hacemos un if-else.
            if (numFilasAfectadas > 0)
            {
                throw new Exception();

            }
            else
            {
                //nos lleva a la vista inicial.
                return View("Index");

            }

           
        }

    }
}