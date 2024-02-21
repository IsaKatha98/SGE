using Biblioteca;
using BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio03.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> listaPersonas= new List<clsPersona>();
           

            try
            {
                listaPersonas=clsListaPersonasBL.listadoCompletoPersonasBL();

                if (listaPersonas.Count() == 0)
                {
                    salida = NoContent(); //el listado está vacío

                }
                else
                {
                    salida = Ok(listaPersonas); //hay que mandar la lista con el ActionResult.
                }

            }
            catch (Exception e)
            {
                salida = BadRequest(e);
            }

            return salida;

        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsPersona personaById = new clsPersona();


            try
            {
                personaById = clsListaPersonasBL.getPersonaByIdBL(id);

                if (personaById ==null)
                {
                    salida = NotFound(); //no se encuentra la persona

                }
                else
                {
                    salida = Ok(personaById); //hay que mandar la persona con el ActionResult.
                }

            }
            catch (Exception e)
            {
                salida = BadRequest(e);
            }

            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] clsPersona persona)
        {

            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = clsManejadoraBL.createPersonaBL(persona);

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

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] clsPersona persona)
        {

            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = clsManejadoraBL.createPersonaBL(persona);

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

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = clsManejadoraBL.deletePersonaBL(id);

                if (numFilasAfectadas==0)
                {
                    salida = NotFound(); //no se ha hecho
                
                } else
                {
                    salida = Ok(); //se ha borrado 
                }
            
            } catch (Exception e)
            {
                salida= BadRequest(e);
            }

            return salida;
        }
    }
}
