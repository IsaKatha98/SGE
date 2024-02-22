using BL;
using DAL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
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
            List<clsPersona> listadoCompleto = new List<clsPersona>();
          
            try
            {
               
                listadoCompleto = clsListadoPersonasBL.ListadoCompletoPersonasBL();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            clsPersona miPersona;
            IActionResult salida;

            try
            {
                miPersona = clsListadoPersonasDAL.personaPorId(id);
                //Si no encuentra la persona
                if (miPersona.Id == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(miPersona);
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }
            return salida;
        }


    }
}
