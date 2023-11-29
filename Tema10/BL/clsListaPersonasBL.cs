using Biblioteca;
using DAL.Listados;
using DAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class clsListaPersonasBL
    {
        /// <summary>
        /// Función que devuelve un listado de personas obtenido de la DAL
        /// y aplicando las reglas de negocio.
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona>listadoCompletoPersonasBL()
        {
            return clsListadoPersonas.getListadoPersonas();
        }

        public static clsPersona getPersonaByIdBL(int id)
        {

            return clsManejadoraPersonaDAL.readDetailsPersonaDAL(id);

         }
    }
}
