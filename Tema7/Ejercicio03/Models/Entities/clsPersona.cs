using System.Globalization;

namespace Ejercicio03.Models.Entities
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellidos;
        private int idDepartamento;
        private int idPersona;

        #endregion

        #region constructores
        public clsPersona() {

            nombre = "";
            apellidos = "";

        }

        public clsPersona(string nombre, string apellidos, int idDepartamento, int idPersona)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDepartamento = idDepartamento;
            this.idPersona = idPersona;
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

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        
        }
        #endregion
    }
}
