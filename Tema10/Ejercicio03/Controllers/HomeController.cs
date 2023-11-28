using Ejercicio03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Biblioteca;
using DAL;
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

        public IActionResult Details() {
            

            return View();
        }

    }
}