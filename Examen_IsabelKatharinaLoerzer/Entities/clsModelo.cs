using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsModelo
    {
        #region atributos
        int idModelo;
        int idMarca;
        string nombre;
        int precio;
        #endregion

        #region constructores
        public clsModelo()
        {
            idModelo = 0;
            idMarca = 0;
            nombre = string.Empty;
            precio = 0;

        }

        public clsModelo(int idModelo, int idMarca, string nombre, int precio)
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
            get { return idModelo; } 
            set {idModelo = value; }
        }
        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        #endregion

    }
}
