using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handler
{

    public static class clsHandlerMarcas
    {
        /// <summary>
        /// Función que devuelve un objeto marca que encuentra en el listado de marcas de la clsListadoMarcasDAL.
        /// Aquí habreía una sentencia SQL de tipo select* from Marcas donde el id es el id que le
        /// pasamos por parámetros.
        /// </summary>
        /// <param name="idMarca">id que le llega desde la capa BL</param>
        /// <returns>devuelve un clsMarca</returns>
        public static clsMarca getMarcaById (int idMarca)
        {
            return new clsMarca();
        }
    }
}
