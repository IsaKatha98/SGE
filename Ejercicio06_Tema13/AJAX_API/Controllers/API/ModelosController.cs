using DAL.Listados;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        // GET: api/<MarcasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsModelos> listaModelos = new List<clsModelos>();

            try
            {
                listaModelos = clsListadoModelosDAl.getListadoModelosDAL();
                if (listaModelos.Count() == 0)
                {
                    salida = NoContent(); //el listado está vacío.
                }
                else
                {
                    salida = Ok(listaModelos); //mandamos la lista
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }

            return salida;
        
    }
        // PUT: ModelosController/Edit/5
        [HttpPut]
        public IActionResult Put(int idModelo, int precio)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = HandlerModelosDAL.updatePrecioModeloDAL(idModelo, precio);

                if (numFilasAfectadas == 0)
                {
                    salida = NotFound(); //no se ha hecho

                }
                else
                {
                    salida = Ok(); //se ha borrado 
                }

            }
            catch (Exception e)
            {
                salida = BadRequest(e);
            }

            return salida;
        }

    }
}
