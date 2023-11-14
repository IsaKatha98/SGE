using System.Globalization;

namespace Ejercicio03.Models.Entities
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellidos;
        private int idDepartamento;

        #endregion

        #region constructores
        public clsPersona() {

            nombre = "";
            apellidos = "";

        }

        public clsPersona(string nombre, string apellidos, int idDepartamento)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDepartamento = idDepartamento;

        }
        #endregion

        #region propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }

        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value;}
        }
        #endregion
    }
}
