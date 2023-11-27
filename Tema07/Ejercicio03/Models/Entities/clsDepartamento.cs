namespace Ejercicio03.Models.Entities
{
    public class clsDepartamento
    {
        #region atributos
        int idDepartamento;
        string nombreDepartamento;
        #endregion

        #region constructores
        public clsDepartamento()
        {
            idDepartamento = 0;
            nombreDepartamento = "";
        }

        public clsDepartamento(int idDepartamento, string nombreDepartamento)
        {
            this.idDepartamento = idDepartamento;
            this.nombreDepartamento = nombreDepartamento;
        }
        #endregion

        #region propiedades
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }

        }

        public string NombreDepartamento
        {
            get { return nombreDepartamento; }
            set { nombreDepartamento = value; }

        }

        #endregion
    }

}




