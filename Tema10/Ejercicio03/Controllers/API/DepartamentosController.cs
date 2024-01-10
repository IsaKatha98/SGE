using Biblioteca;
using BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// URL de mi api= "crudisasegundo/api"
namespace Ejercicio03.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsDepartamento> listaDept = new List<clsDepartamento>();


            try
            {
                listaDept = clsListadoDepartamentosBL.listadoCompletoDepartamentosBL();

                if (listaDept.Count() == 0)
                {
                    salida = NoContent(); //el listado está vacío

                }
                else
                {
                    salida = Ok(listaDept); //hay que mandar la lista con el ActionResult.
                }

            }
            catch (Exception e)
            {
                salida = BadRequest(e);
            }

            return salida;
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsDepartamento deptById = new clsDepartamento();


            try
            {
                deptById = clsListadoDepartamentosBL.getDepartamentoByIdBL(id);

                if (deptById == null)
                {
                    salida = NotFound(); //no se encuentra el departamento

                }
                else
                {
                    salida = Ok(deptById); //hay que mandar el departamento con el ActionResult.
                }

            }
            catch (Exception e)
            {
                salida = BadRequest(e);
            }

            return salida;
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public IActionResult Post([FromBody] clsDepartamento dept)
        {
            IActionResult salida=null;

            return salida ;

        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
