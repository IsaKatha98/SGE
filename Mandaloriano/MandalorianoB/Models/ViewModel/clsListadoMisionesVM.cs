using MandalorianoB.DAL;
using MandalorianoB.Entidades;

namespace MandalorianoB.Models.ViewModel
{
    public class clsListadoMisionesVM
    {
        #region atributos
        private List<clsMision> listadoMisiones;
        private clsMision misionActual;


        #endregion

        #region constructores
        public clsListadoMisionesVM(List<clsMision> listadoMisiones, clsMision misionActual)
        {
            //Asignamos el listado de misiones al listado que devuelve la clase DAL.
            this.listadoMisiones = listadoMisiones;
            this.misionActual = misionActual;

        }
        #endregion

        #region propiedades
        public List<clsMision> ListadoMisiones
        {
            get { return listadoMisiones; }
        }

        public clsMision MisionActual
        {
            get { return misionActual; }

        }
        #endregion
    }
}
