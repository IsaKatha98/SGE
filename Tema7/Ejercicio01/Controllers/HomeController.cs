using Ejercicio01.Models;
using Ejercicio01.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio01.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index()
        {
            var fechaActual=DateTime.Now;
            var mensaje = "Buenos días";

            if (fechaActual.Hour>=12)
            {
                mensaje = "Buenas tardes";

            } else if (fechaActual.Hour>=21)
            {
                mensaje = "Buenas noches";
            }

            ViewData["Mensaje"] = mensaje;
            ViewBag.fecha = fechaActual.ToLongDateString();
            return View();
        }
        private clsPersona persona = new clsPersona()
        {
            Id = 1,
            Nombre = "Isabel Katharina",
            Apellidos = "Loerzer",
            Direccion = "Av de la Paz",
            FechaNac = new DateTime(1998, 12, 05),
            Telefono = 654444089,
        };
    }
}