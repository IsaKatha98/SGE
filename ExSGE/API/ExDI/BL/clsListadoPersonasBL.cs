

using DAL;
using Entidades;

namespace BL
{

    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Función que llama a la DAL para pedir el listado completo de personas.
        /// Aplicará las reglas de negocio necesarias si existen
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> ListadoCompletoPersonasBL()
        {
            return clsListadoPersonasDAL.ListadoCompletoPersonasDAL();
        }

        /// <summary>
        /// Función que llama a la DAL para pedir una persona.
        /// Aplicará las reglas de negocio necesarias si existen
        /// Pre: La id proporcionada debe ser un id de persona que exista
        /// </summary>
        /// <param name="id">id de la persona</param>
        /// <returns></returns>
        public static clsPersona personaPorIdBL(int id)
        {
            return clsListadoPersonasDAL.personaPorId(id);
        }
    }
}