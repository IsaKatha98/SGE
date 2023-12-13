using DAL.Listados;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handler
{
    public static class clsHandlerModelos
    {
        /// <summary>
        /// Función que devuelve un objeto modelo que encuentra en el listado de marcas de la clsListadoMarcasDAL.
        /// Aquí habreía una sentencia SQL de tipo select* from Modelos donde el id es el id que le
        /// pasamos por parámetros.
        /// </summary>
        /// <param name="idModelo">id que le llega desde la capa BL</param>
        /// <returns>un objeto clsModelo donde se han leído los datos de la tabla encontrada.</returns>
        public static clsModelo getModeloById(int idModdelo)
        {
            //corrección
            bool encontrado = false;
            int cont = 0;

            //TODO:hacemos una búsqueda dentro de un bucle while
            while (!encontrado&& cont>=clsListadoModelosDAL.getListadoModelosDAL)
            
            return new clsModelo();
        }

        /// <summary>
        /// Función que edita el precio de un modelo cuyo id le pasamos por parámetro.
        /// Aquí habría una secuencia SQL que actualiza el precio.
        /// Devuelve el número de filas afectadas, 0 si no se ha actualizado la BBDD; y 1 si se ha actualizado.
        /// </summary>
        /// <param name="clsModelo modelo"></param>
        /// <returns>int numFilasAfectadas</returns>
        public static int editPrecio(clsModelo modelo)
        {
            int numFilasAfectadas = 0;
            return numFilasAfectadas;

        }
    }
}
