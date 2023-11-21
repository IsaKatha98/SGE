using MandalorianoB.DAL;
using MandalorianoB.Entidades;

namespace MandalorianoB.Models.ViewModel
{
    public class clsListadoMisionesVM
    {
        #region atributos
        private List<clsMision> listadoMisiones;
        private clsMision mision;


        #endregion

        public clsListadoMisionesVM(List<clsMision> listadoMisiones, clsMision mision)
        {
            //Asignamos el listado de misiones al listado que devuelve la clase DAL.
            this.listadoMisiones = listadoMisiones;
            this.mision = mision;

        }

        /// <summary>
        /// Esta propiedad devolverá una listado de Misiones
        /// </summary>
        public List<clsMision> ListadoMisiones
        {
            get { return listadoMisiones; }
        }

        public clsMision Mision
        {
            get { return mision; }

        }
    }
}
