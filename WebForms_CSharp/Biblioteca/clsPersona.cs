using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class clsPersona
    {
        #region atributos

        string nombre;

        #endregion

        #region constructor

        clsPersona(String nombre)
        {
            this.nombre = nombre;
        }
        #endregion

        #region propiedades
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        #endregion


    }
}
