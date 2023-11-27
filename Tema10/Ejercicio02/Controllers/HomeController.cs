using Ejercicio02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DAL.Listados;

namespace Ejercicio02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();

        }

        public ActionResult listadoPersonas()
        {
            try
            {
                return View(clsListadoPersonas.getListadoPersonas());
            
            } catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}