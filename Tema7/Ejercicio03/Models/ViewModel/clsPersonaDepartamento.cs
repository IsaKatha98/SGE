using Ejercicio03.Models.Entities;
using Ejercicio03.Models.DAL;

namespace Ejercicio03.Models.ViewModel
{
    //Esta clase heredad de la clase Persona
    public class clsPersonaDepartamento:clsPersona
    {
        #region atributos
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores
        public clsPersonaDepartamento()
        {
            //Lo metemos en el constructor para que siempre que se instancie un objeto
            //de esta clase ya vaya rellena esta propiedad.
            listaDepartamentos = clsListadoDepartamentos.listadoDept();
            this.Nombre="Isabel";
            this.Apellidos = "Loerzer";
            this.IdDepartamento = 1;
            this.IdPersona = 1;
        }
        #endregion

        #region propiedades

        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos;}
        }
        #endregion

    }
}
