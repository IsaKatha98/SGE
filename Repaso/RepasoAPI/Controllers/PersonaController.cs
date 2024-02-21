using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL.Listados;
using DAL.Manejadoras;

namespace RepasoAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET: api/<ModelosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> listaPersonas = new List<clsPersona>();

            try
            {
                listaPersonas = clsListadoPersonasDAL.getListadoPersonas();
                if (listaPersonas.Count() == 0)
                {
                    salida = NoContent(); //el listado está vacío.
                }
                else
                {
                    salida = Ok(listaPersonas); //mandamos la lista
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }

            
            
            return salida;

        }

        // PUT: ModelosController/Edit/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] clsPersona p)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = clsHandlerPersonaDAL.updatePersonaDAL(p);

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
