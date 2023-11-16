using Ejercicio03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio03.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar ()
        {
            clsPersona clsPersona = new clsPersona();
            
            return View();
        }

        public IActionResult PersonaModificada ()
        {
            return View();
        }

    }
}