using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{

    public static class clsListadoMarcasDAL
    {
        /// <summary>
        /// Aquí habreía una sentencia SQL de tipo select* from Marcas.
        /// </summary>
        /// <returns>una lista con todas las marcas</returns>
        public static List<clsMarca> getListadoMarcasDAL()
        {

            List<clsMarca> marca= new List<clsMarca>(){
            new clsMarca() {IdMarca=1, Nombre="Ford"},
            new clsMarca() {IdMarca=2, Nombre="Renault"}


            };
            return marca;
        }
       
    }
}
