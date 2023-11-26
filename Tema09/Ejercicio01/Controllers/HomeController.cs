using Ejercicio01.Models;
using Ejercicio01.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Este controller instancia una variable persona y la manda a la vista.
        public IActionResult Editar()
        {
            clsPersona persona = new clsPersona();
            return View(persona);
        }
        
        //Hace cambios en la vista Editar y recibe por párametros estos cambios a
        //través de la clsPersona. Estosa cambios se guardarán, y devolverá la vista
        //PersonaModificada. Hay que mandarle persona porque va a ser el modelo de 
        //dicha vista.
        [HttpPost]
         public ActionResult Editar (clsPersona persona)
        {
            return View("PersonaModificada", persona);

        }

       
    }
}