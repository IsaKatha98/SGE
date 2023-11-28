using Biblioteca;
using DAL;

namespace Ejercicio03.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class clsListadoPersonasVM:clsDepartamento
    {
        #region atributos

        private List<clsPersona> listadoPersonas;
        private clsPersona persona;
        string nombreDepartamento;
        #endregion

        #region constructores
        public clsListadoPersonasVM(List<clsPersona>listadoPersonas, clsPersona persona)
        {
            this.listadoPersonas = listadoPersonas;
            this.persona = persona;
            
        }
        #endregion

        #region propiedades
        public List<clsPersona> ListadoPersonas
        {
            get { return listadoPersonas; }
        }
        public clsPersona Persona
        {
            //solo tiene un get porque no se puede modificar nada en esta vista.
            get { return persona;}
        }

        public string NombreDepartamento
        {
            get { return nombreDepartamento; }
            set { nombreDepartamento = value; }
        }
        #endregion
    }
}
