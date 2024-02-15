using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsModelos
    {
        #region atributos
        private int idModelo;
        private int idMarca;
        private string nombre;
        private int precio;
        #endregion

        #region constructores
        public clsModelos()
        {
            this.idModelo = 0;
            this.idMarca = 0;
            this.nombre = string.Empty;
            this.precio = 0; 
        }

        public clsModelos(int idModelo, int idMarca, string nombre, int precio)
        {
            this.idModelo = idModelo;
            this.idMarca = idMarca;
            this.nombre = nombre;
            this.precio = precio;
        }
        #endregion

        #region propiedades

        public int IdModelo
        {
            get { return this.idModelo; }
            set { this.idModelo = value;}
        }
        public int IdMarca
        {
            get { return this.idMarca; }
            set { this.idMarca = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public int Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        #endregion
    }
}
