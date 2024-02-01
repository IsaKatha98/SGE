using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsMarcas
    {
        #region atributos
        private int idMarca;
        private string nombre;
        #endregion

        #region constructores
        public clsMarcas()
        {
            this.idMarca = 0;
            this.nombre=string.Empty;
        }

        public clsMarcas(int idMarca, string nombre)
        {
            this.idMarca = idMarca;
            this.nombre = nombre;   
        }
        #endregion

        #region propiedades
        public int IdMarca
        {
            get { return this.idMarca; }
            set { this.idMarca = value;}
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        #endregion
    }
}
