using DAL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listados
{
    public class clsListadoModelosBl
    {
        /// <summary>
        /// Llama a la función de getListadoModel9osDAL de la capa DAL.
        /// </summary>
        /// <returns>una lista con todos los modelos</returns>
        public static List<clsModelo> getListadoModelosBL()
        {
            return clsListadoModelosDAL.getListadoModelosDAL();
        }
    }
}
