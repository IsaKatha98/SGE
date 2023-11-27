using Ejercicio03.Models.Entities;
using Ejercicio03.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio03.Controllers
{
    public class EditarPersonaController : Controller
    {
    /// <summary>
    /// Action Result que devuelve la vista con el listado de personas
    /// asignadas a un departamento.
    /// 
    /// Post: siempre devuelve algo
    /// </summary>
    /// <returns>Devuelve la vista EditarPersona</returns>
        public IActionResult EditarPersona()
        {
            //Instanciaamos un objeto del modelo y lo mandamos a la vista
            clsPersonaDepartamento objetoEditarPersona = new clsPersonaDepartamento();

            return View(objetoEditarPersona);
          
        }

        [HttpPost]
        public IActionResult GuardarPersona(clsPersona persona)
        {
            return View();
        }



    }
}
