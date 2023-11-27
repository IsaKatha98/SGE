using Microsoft.AspNetCore.Mvc;

namespace Tema6_MDV.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult ListadoProductos()
        {
            return View();
        }
    }
}
