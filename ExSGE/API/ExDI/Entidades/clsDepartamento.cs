

namespace Entidades
{
    public class clsDepartamento
    {

        #region Constructores
        public clsDepartamento()
        {
            this.Id = 0;
            this.Nombre = "";
        }

        //Constructor por parametros

        public clsDepartamento(int Id, string Nombre)
        {

            this.Id = Id;
            this.Nombre = Nombre;

        }
        public clsDepartamento(clsDepartamento depart)
        {

            Id = depart.Id;
            Nombre = depart.Nombre;

        }
        #endregion

        #region Propiedades autoimplementadas
        public int Id { get; set; }
        public string Nombre { get; set; }
        #endregion

    }
}
