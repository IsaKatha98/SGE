using Ejercicio03.Models.Entities;
using Ejercicio03.Models.DAL;

namespace Ejercicio03.Models.ViewModel
{
    //Esta clase heredad de la clase Persona
    public class clsPersonaDepartamento:clsPersona
    {
        #region atributos
        private List<clsPersona> listaPersonas;
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores
        public clsPersonaDepartamento()
        {
            listaPersonas = clsListadoPersonas.listadoPersonas();
            listaDepartamentos = clsListadoDepartamentos.listadoDept();
        }
        #endregion

        #region propiedades
        public List<clsPersona> ListaPersonas
        {
            get { return listaPersonas; }
        }

        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos;}
        }
        #endregion

    }
}
