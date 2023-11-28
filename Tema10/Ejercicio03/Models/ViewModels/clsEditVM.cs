using Biblioteca;
using DAL.Listados;

namespace Ejercicio03.Models.ViewModels
{
    //hereda de la clsPersona
    public class clsEditVM:clsPersona
    {
        #region atributos
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores
        public clsEditVM()
        {
            //Lo metemos en el constructor para que siempre que se instancie un objeto
            //de esta clase ya vaya rellena esta propiedadd. 
            listaDepartamentos = clsListadoDepartamentosDAL.getListadoDepartamentos();
           
        }
        #endregion

        #region propiedades

        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
        }
        #endregion
    }
}
