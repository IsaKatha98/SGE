using System.ComponentModel.DataAnnotations;

namespace Biblioteca
{
    public class clsPersona
    {
        #region atributos
        private int idPersona;
        private string nombre;
        private string apellidos;
        private string direccion;
        private string tlf;
        private string fotoURL;
        private DateTime fechaNac;
        private int idDepartamento;
        

        #endregion

        #region constructores
        public clsPersona()
        {
            idPersona = 0;
            nombre = "";
            apellidos = "";
            direccion=string.Empty;
            tlf = string.Empty;
            fotoURL = string.Empty;
            fechaNac = new DateTime();
            idDepartamento = 0;
            


        }

        public clsPersona(int idPersona,string nombre, string apellidos,string direccion, string tlf, string fotoURL, DateTime fechaNac, int idDepartamento)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion=direccion;
            this.tlf = tlf;
            this.fotoURL = fotoURL;
            this.fechaNac = fechaNac;
            this.idDepartamento=idDepartamento; 
           
        }
        #endregion

        #region propiedades

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }

        }
        public string Nombre
        {
            get { return nombre; }
            set
            {

                nombre = value;


            }
        }
        [Required(ErrorMessage = "Campo obligatorio")]

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;

            }

        }
        [Required(ErrorMessage = "Campo obligatorio")]

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Tlf
        {
            get { return tlf; }
            set { tlf = value; }

        }

        public string FotoURL
        {
            get { return fotoURL; }
            set { fotoURL = value; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        [Required(ErrorMessage="Campo Obligatorio")]

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellidos; }

        }
        #endregion
    }
}