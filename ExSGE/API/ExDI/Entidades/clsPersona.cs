

namespace Entidades
{
    public class clsPersona
    {
        #region constructores
        //Constructor por defecto
        public clsPersona()
        {
            Id = 0;
            Nombre = "";
            Apellidos = "";
            FechaNac = new DateTime();
            Direccion = "";
            Telefono = "";
            Foto = "";
            IdDepartamento = 0;

        }

        //Constructor por parametros

        public clsPersona(int Id, string Nombre, string Apellidos, DateTime FechaNac, string Direccion, string Telefono, string Foto, int IdDepartamento)
        {

            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.FechaNac = FechaNac;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Foto = Foto;
            this.IdDepartamento = IdDepartamento;
        }

        public clsPersona(clsPersona p)
        {

            this.Id = p.Id;
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
            this.FechaNac = p.FechaNac;
            this.Direccion = p.Direccion;
            this.Telefono = p.Telefono;
            this.Foto = p.Foto;
            this.IdDepartamento = p.IdDepartamento;
        }
        #endregion

        #region Propiedades autoimplementadas

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNac { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Foto { get; set; }
      
        public int IdDepartamento { get; set; }

        #endregion
    }
}