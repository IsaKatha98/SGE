using Ejercicio02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio02.Controllers
{
    public class HomeController : Controller
    {
       //Action de la primera vez que el usuario pide la página.
        public IActionResult Index()
        {
            return View();
        }

        //Action cuando el usuario ha pulsado el botón.
        //Se trata de decirle donde quiere que se envíen los datos.
        [HttpPost]
        public IActionResult Index (string nombre)
        {
            ViewBag.nombre = nombre;

            //Esto devuelve la vista Index, es decir, a la misma vista en la 
            //que recogemos los datos.
            //return View ()

            //Ahora devuelve una vista que se llama Saludo.
            return View("Saludo");
        }

      
    }
}