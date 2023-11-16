using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ejercicio03.Models
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellidos;
        private int idPersona;

        #endregion

        #region constructores
        public clsPersona()
        {

            nombre = "Isabel Katharina";
            apellidos = "Loerzer";
            idPersona = 1;

        }

        public clsPersona(string nombre, string apellidos, int idPersona)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idPersona = idPersona;
        }
        #endregion

        #region propiedades
        public string Nombre
        {
            get { return nombre; }
            set
            {

                nombre = value;


            }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;

       

            }

        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }

        }

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellidos; }

        }
        #endregion
    }
}
