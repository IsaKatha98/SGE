using Mandaloriano.Models.DAL;
using Mandaloriano.Models.Entidades;

namespace Mandaloriano.Models.ViewModel
{
    public class clsListadoMisionesVM:clsMision
    {
        #region atributos
        private List<clsMision> listadoMisiones;

        #endregion

        public clsListadoMisionesVM() 
        { 
            //Asignamos el listado de misiones al listado que devuelve la clase DAL.
            listadoMisiones=clsListadoMisionesDAL.listadoMisiones();
            
              
        }

     

        /// <summary>
        /// Esta propiedad devolverá una listado de Misiones
        /// </summary>
        public List<clsMision> ListadoMisiones
        { 
            get { return listadoMisiones; } 
        }


        public static clsMision BuscaMision( int id)
        {
            List<clsMision> misiones = clsListadoMisionesDAL.listadoMisiones();
            
            //Recorremos la lista de misiones con un for-each.
            foreach (clsMision mision in misiones)
            {
                if (mision.Id == id)
                {
                    return mision;
                }

            }

            return new clsMision();

        }


    }
}
