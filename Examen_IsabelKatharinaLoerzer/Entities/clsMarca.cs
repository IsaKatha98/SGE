namespace Entities
{
    public class clsMarca
    {
        #region atributos
        int idMarca;
        string nombre;
        #endregion

        #region constructores
        public clsMarca()
        {
            idMarca = 0;
            nombre=string.Empty;
        }

        public clsMarca (int idMarca, string nombre)
        {
            this.idMarca = idMarca;
            this.nombre = nombre;
        }
        #endregion

        #region propiedades
         public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }    
        }
        public string Nombre
        {
            get { return nombre; }
            set {  nombre=value; }
        }
       
        #endregion




    }
}