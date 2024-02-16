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
        // GET: api/<ModelosController>
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
        [Route("byMarca/{idMarca}")]
        //GET:api/<ModelosPorIdMarcaController>/idMarca
        [HttpGet]
        public IActionResult Get(int idMarca) {

            IActionResult salida;
            List<clsModelos> listaModelosByIdMarca= new List<clsModelos>();

            try
            {
                listaModelosByIdMarca = clsListadoModelosDAl.getListadoModelosByIdMarcaDAL(idMarca);

                if (listaModelosByIdMarca.Count() == 0)
                {
                    salida = NoContent(); //el listado está vacío.
                }
                else
                {
                    salida = Ok(listaModelosByIdMarca); //mandamos la lista

                }

            } catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }

            return salida;
        
        }




        // PUT: ModelosController/Edit/5
        [Route("{idModelo}")]
        [HttpPut]
        public IActionResult Put(int idModelo,[FromBody] clsModelos modelo)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = HandlerModelosDAL.updatePrecioModeloDAL(idModelo, modelo.Precio);

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
