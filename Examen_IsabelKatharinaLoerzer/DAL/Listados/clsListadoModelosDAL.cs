using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{
    /// <summary>
    /// Esta clase genera un listado con todos los modelos de coche.
    /// </summary>
    public static class clsListadoModelosDAL
    {
        /// <summary>
        /// Función que se conecta con la base de datos y ejecuta un comando select * from Modelos.
        /// </summary>
        /// <returns>devuelve una lista con todos los registros de la tabla modelos</returns>
        public static List<clsModelo> getListadoModelosDAL()
        {
            List<clsModelo> modelo = new List<clsModelo>(){
            new clsModelo() {IdModelo=1, IdMarca=1, Nombre="Focus", Precio=25000},
            new clsModelo() {IdModelo=1, IdMarca=2, Nombre="Kuga", Precio=35000}


            };
            return modelo;
        }
    }
}
