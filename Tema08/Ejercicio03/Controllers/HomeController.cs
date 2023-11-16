using Ejercicio03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio03.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Editar()
        {
            clsPersona persona = new clsPersona();
            return View(persona);
        }

        
        [HttpPost]

        //Esto recoge un objeto persona y la manda a la 
        //vsita PersonaModificada
        public IActionResult Editar (clsPersona persona)
        {
            
            return View("PersonaModificada", persona);
        }

    }
}