namespace Ejercicio01.Models.DAL
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellidos;
        private DateTime fechaNac;
        private long telefono;
        private int id;
        private int idDepartamento;
        #endregion

        #region constructores
        public clsPersona()
        {
            nombre = "";
            apellidos = "";
        }

        public clsPersona(int id, string nombre, string apellidos, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDepartamento = idDepartamento;
        }

        public clsPersona(int id, string nombre, string apellidos, DateTime fechaNac, long telefono, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono= telefono;
            this.fechaNac = fechaNac;
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
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }
        public long Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        public string NombreCompleto
        {
            get { return $"{nombre} {apellidos}"; }
        }
        public string Direccion { get; set; }
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
