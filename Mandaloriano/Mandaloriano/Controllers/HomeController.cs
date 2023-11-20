using Mandaloriano.Models;
using Mandaloriano.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Mandaloriano.Models.DAL;
using Mandaloriano.Models.Entidades;
using System.Diagnostics;

namespace Mandaloriano.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            //Instanciaamos un objeto del modelo y lo mandamos a la vista
            clsListadoMisionesVM listadoMisiones = new clsListadoMisionesVM();
            
            return View(listadoMisiones);
        }

        [HttpPost]
        public IActionResult Index (int idMision)
        {
            //Instanciaamos un objeto del modelo y lo mandamos a la vista
            clsListadoMisionesVM listadoMisiones = new clsListadoMisionesVM();

            clsMision mision = clsListadoMisionesVM.BuscaMision(idMision);

            return View(listadoMisiones);


          
        }



      
    }
}