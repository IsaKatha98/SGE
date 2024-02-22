

using DAL;
using Entidades;

namespace BL
{
    public class clsListadoDepartamentosBL
    {
        /// <summary>
        /// Función que llama a la DAL para pedir el listado completo de departamentos.
        /// Aplicará las reglas de negocio necesarias si existen
        /// </summary>
        /// <returns></returns>
        public static List<clsDepartamento> ListadoCompletoDepartamentosBL()
        {
            return clsListadoDepartamentosDAL.ListadoCompletoDepartamentosDAL();
        }


        /// <summary>
        /// Función que llama a la DAL para pedir un departamento.
        /// Aplicará las reglas de negocio necesarias si existen
        /// Pre: La id proporcionada debe ser un id de departamento que exista
        /// </summary>
        /// <param name="id">id del departamento</param>
        /// <returns></returns>
        public static clsDepartamento departamentoPorIdBL(int id)
        {
            return clsListadoDepartamentosDAL.departamentoPorId(id);
        }
    }
}
