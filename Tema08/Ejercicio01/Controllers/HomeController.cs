using Ejercicio01.Models;
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

        //Recogemos un string con el nombre por parámetro y lo asignamos
        //al viewbag de Saludo.
        public IActionResult Saludo (string nombre)
        {
            ViewBag.nombre = nombre;
            return View();
        }
    }
}