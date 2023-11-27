namespace Ejercicio01.Models.DAL
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellidos;
       
        #endregion

        #region constructores
        public clsPersona()
        {
            nombre = "";
            apellidos = "";
        }

        public clsPersona(string nombre, string apellidos)
        {
  
            this.nombre = nombre;
            this.apellidos = apellidos;

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
      
        #endregion
        #region funciones y metodos
        ///<summary>
        ///Funcion que devuelve la concatenacion del atributo nombre y el atributo apellido
        ///Precondiciones: ninguna
        ///Postcondiciones: primera letra de cada palabra sea mayúscula, que no sea null... etc.
        ///</summary>
        ///<returns>string con el nombre completo</returns>
        public string FuncionNombreCompleto()
        {
            return $"Su nombre completo es: {nombre} {apellidos}";
        }
        #endregion
    }
}
