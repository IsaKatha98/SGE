using Biblioteca;
using BL;

namespace Ejercicio03.Models.ViewModels
{
    //Esta clase hereda de la clsPersona
    public class clsPersonaListadoDepartamentos:clsPersona
    {
        #region atributos
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores
        public clsPersonaListadoDepartamentos(clsPersona persona)
        {
            //Lo metemos en el constructor para que siempre que se instancie un objeto
            //de esta clase ya vaya rellena esta propiedad.
            listaDepartamentos = clsListadoDepartamentosBL.listadoCompletoDepartamentosBL();

             //Asociamos las propiedades de esta clase con la del objeto que nos llega.
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Tlf = persona.Tlf;
            this.Direccion = persona.Direccion;
            this.FechaNac = persona.FechaNac;
            this.Id = persona.Id;
            this.IdDepartamento = persona.IdDepartamento;
            this.FotoURL = persona.FotoURL;
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
