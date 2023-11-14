using Ejercicio03.Models.DAL;
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
            return View(clsListadoPersonaConDept.listadoPersonasConDept());
           
        }
    }
}
