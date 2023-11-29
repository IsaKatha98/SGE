using Biblioteca;
using DAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsManejadoraBL
    {
        /// <summary>
        /// Función que llama a la DAL y devuelve el número de filas afectadas al borrar una persona
        /// que recibe como parámetro y aplica las normas de negocio.
        /// Post: mi salida siempre será o 0, o 1, o -1.
        /// </summary>
        /// <param name="id">Id de la persona a borrar</param>
        /// <returns></returns>
        public static int deletePersonaBL(int id)
        {
            DateTime fechaActual = DateTime.Now;
            int numFilasAfectadas=0;

            if (fechaActual.DayOfWeek== DayOfWeek.Wednesday)
            {
                numFilasAfectadas = -1;
            }
            else
            {
                numFilasAfectadas = clsManejadoraPersonaDAL.deletePersonaDAL(id);
            }
           
            return numFilasAfectadas;
        }

        public static int editPersonaBL(clsPersona persona)
        {
            int numFilasAfectadas = 0;

            numFilasAfectadas = clsManejadoraPersonaDAL.updatePersonaDAL(persona);

            return numFilasAfectadas;
        }
       

    }
}
