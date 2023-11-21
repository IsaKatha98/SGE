namespace MandalorianoB.Entidades
{
    public class clsMision
    {

        #region atributos
        private int id;
        private string titulo;
        private string descripcion;
        private int creditos;
        #endregion

        #region constructores
        public clsMision()
        {
            id = 0;
            titulo = string.Empty;
            descripcion = string.Empty;
            creditos = 0;
        }

        public clsMision(int id, string titulo, string descripcion, int creditos)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.creditos = creditos;
        }
        #endregion

        #region propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Creditos
        {
            get { return creditos; }
            set { creditos = value; }
        }
        #endregion
    }
}
