using BL.Listados;
using Entities;

namespace IU.Models.ViewModels
{
    public class clsListadoMarcasListadoModelosObjModelo: clsModelo
    {
        #region atributos
        private List<clsMarca> listaMarcas;
        private List<clsModelo> listaModelos;
        #endregion

        #region constructores
        public clsListadoMarcasListadoModelosObjModelo()
        {
            //Llamamos a la función de listar las marcas de la capa BL.+
            listaMarcas= clsListadoMarcasBL.getListadoMarcasBL();
        }
        public clsListadoMarcasListadoModelosObjModelo(int idMarca)
        {
        
            //Llamamos a la función de listar los modelos de la capa BL.+
            listaModelos = clsListadoModelosBl.getListadoModelosBL();

        }

        public clsListadoMarcasListadoModelosObjModelo(clsModelo modelo)
        {
    

            //Llamamos a la función de listar los modelos de la capa BL.+
            listaModelos = clsListadoModelosBl.getListadoModelosBL();

            this.IdModelo = modelo.IdModelo;
            this.Nombre = modelo.Nombre;
            this.Precio = modelo.Precio;
            this.IdMarca = modelo.IdMarca;

        }
        #endregion

        #region propiedades
        public List<clsMarca> ListaMarcas
        {
            get { return listaMarcas; }
        }
        public List<clsModelo> ListaModelos
        {
            get { return listaModelos; }
        }
        #endregion
    }
}
