using DAL.Handler;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Handler
{
    public static class clsHandlerMarcasBL
    {
        /// <summary>
        /// Función que devuelve un objeto marca que llama desde la función getMarcaByID de la capa DAL.
        /// </summary>
        /// <param name="idMarca">id que le llega desde el controller</param>
        /// <returns>devuelve un clsMarca</returns>
        public static clsMarca getMarcaByIdBL(int idMarca)
        {
            return clsHandlerMarcas.getMarcaById(idMarca);
        }
        
    }
}
