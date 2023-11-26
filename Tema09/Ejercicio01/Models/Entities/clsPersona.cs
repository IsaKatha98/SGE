using System.ComponentModel.DataAnnotations;

namespace Ejercicio01.Models.Entities
{
    public class clsPersona
    {
        #region atributos
        private int idPersona;
        private string nombre;
        private string apellidos;
        private DateOnly fechaNac;
        private string direccion;
        private string tlf;


        #endregion

        #region constructores
        public clsPersona()
        {
            idPersona = 0;
            nombre = "";
            apellidos = "";
            fechaNac = new DateOnly();
            direccion = "";
            tlf = "";


        }

        public clsPersona(int idPersona, string nombre, string apellidos, DateOnly fechaNac, string direccion, string tlf)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.tlf = tlf;

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
        [Required(ErrorMessage="Campo obligatorio")]

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;



            }

        }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(40)]

        //Técnicamente no se debe tener un set del idPersona, pero es para poder crear una persona en el controller.
        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; } 

        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [MaxLength(200)]

        [DisplayFormat(DataFormatString ="{6XX-XXX-XXX}", ApplyFormatInEditMode =true)]
        public string Tlf
        {
            get { return tlf; }
            set { tlf = value; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateOnly FechaNac
        {
            get { return fechaNac; }
            set { fechaNac=value;}
        }

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellidos; }

        }
        #endregion
    }
}
