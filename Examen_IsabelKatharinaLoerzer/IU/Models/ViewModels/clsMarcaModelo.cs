using BL.Handler;
using Entities;

namespace IU.Models.ViewModels
{
    public class clsMarcaModelo:clsModelo
    {

        #region atributos
        string marca;


        #endregion

        #region cosntructores
        public clsMarcaModelo(clsModelo modelo)
        {

            clsMarca marcaAux = clsHandlerMarcasBL.getMarcaByIdBL(modelo.IdMarca);

            //Asociamos las propiedades de esta clase con la del objeto que nos llega.
            this.IdModelo = modelo.IdModelo;
            this.IdMarca= modelo.IdMarca;
            this.Nombre = modelo.Nombre;
            this.Precio = modelo.Precio;
            marca= marcaAux.Nombre.ToString();


        }
        #endregion

        #region propiedades
        public String Marca
        {
            //Solo hay get porque en el VM no se va a poder modificar
            get { return marca; }

        }
        #endregion

    }
}
