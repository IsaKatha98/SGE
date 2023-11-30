using Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Handler;

namespace BL.Handler
{
    public static class clsHandlerModelosBL
    {
        /// <summary>
        /// Función que devuelve un objeto modelo que llama desde la función getModeloById de la capa DAL.
        /// </summary>
        /// <param name="idModelo">id que le llega desde el controller</param>
        /// <returns>un objeto clsModelo</returns>
        public static clsModelo getModeloById(int idModelo)
        {

            return clsHandlerModelos.getModeloById(idModelo);
        }

        /// <summary>
        /// Función que aplica una norma de negocio.
        /// Debe comparar si el precio nuevo del modelo es igual o inferior al que ya tenía.
        /// Si es así, numFilasAfectadas=-1
        /// Si no es así, llamará a la función editPrecio de la capa DAL y numFilasAfectadas= será el resultad de dicha función.
        /// </summary>
        /// <param name="clsModelo modelo"></param>
        /// <returns>int numFilasAfectadas</returns>
        public static int editPrecio(clsModelo modelo)
        {
            int numFilasAfectadas = 0;
            //Creamos un objeto que tenga el precio original.
            clsModelo modeloPrecioOG = clsHandlerModelos.getModeloById(modelo.IdModelo);
            if (modelo.Precio >= modeloPrecioOG.Precio || modelo.Precio == modeloPrecioOG.Precio)
            {
                numFilasAfectadas = -1;
            }
            else
            {
                numFilasAfectadas =clsHandlerModelos.editPrecio(modelo);
            }
           
            return numFilasAfectadas;
        }
   
    }
}
