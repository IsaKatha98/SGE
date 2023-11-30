using DAL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listados
{
    public static class clsListadoMarcasBL
    {

        /// <summary>
        /// Llama a la función de getListadoMarcasDAL de la capa DAL.
        /// </summary>
        /// <returns>una lista con todas las marcas</returns>
        public static List<clsMarca> getListadoMarcasBL()
        {
           return clsListadoMarcasDAL.getListadoMarcasDAL();
        }
    }
}
