using BL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
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
            List<clsDepartamento> listadoCompleto = new List<clsDepartamento>();
            
            try
            {                
                listadoCompleto = clsListadoDepartamentosBL.ListadoCompletoDepartamentosBL();
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

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            clsDepartamento miDepartamento;
            IActionResult salida;
          
            try
            {
                miDepartamento = clsListadoDepartamentosBL.departamentoPorIdBL(id);
                //Si no encuentra el departamento
                if (miDepartamento.Id == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(miDepartamento);
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
