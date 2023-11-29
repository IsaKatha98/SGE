using System.ComponentModel.DataAnnotations;

namespace Biblioteca
{
    public class clsPersona
    {
        #region atributos
        private int id;
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
            id = 0;
            nombre = "";
            apellidos = "";
            direccion=string.Empty;
            tlf = string.Empty;
            fotoURL = string.Empty;
            fechaNac = new DateTime();
            idDepartamento = 0;
            


        }

        public clsPersona(int id,string nombre, string apellidos,string direccion, string tlf, string fotoURL, DateTime fechaNac, int idDepartamento)
        {
            //Aquí hay modificar esto, porque el id no te lo puede poner la persona.
            this.id = id;
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

        public int Id
        {
            get { return id; }
            set { id = value; }

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