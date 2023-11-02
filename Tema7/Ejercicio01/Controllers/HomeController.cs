using Ejercicio01.Models;
using Ejercicio01.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio01.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index()
        {
            var fechaActual=DateTime.Now;
            var mensaje = "Buenos días";


            clsPersona persona = new clsPersona();

            if (fechaActual.Hour>=12)
            {
                mensaje = "Buenas tardes";

            } else if (fechaActual.Hour>=21)
            {
                mensaje = "Buenas noches";
            }

            ViewData["Mensaje"] = mensaje;
            ViewBag.fecha = fechaActual.ToLongDateString();

            persona.Nombre = "Isabel Katharina";
            persona.Apellidos = "Loerzer";
          
            return View();
        }
       
       
        public ActionResult listadoPersonas()
        {
            try
            {
                return View(ListaPersonas.listadoPersonas());
            }
            catch (Exception ex) { return View("Error"); //Mandar otra vista return View(otraVista)};
            
        }
    }
        
    }
}