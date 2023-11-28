using Biblioteca;

namespace Ejercicio03.Models.ViewModels
{
 
    public class clsDetallesVM:clsDepartamento
    {
        #region atributos
        clsPersona persona = new clsPersona();
      
        #endregion

        #region contructores
        public clsDetallesVM(clsPersona persona)
        {
            //Asociamos la persona de esta clase con la persona que nos llega del Controler
            this.persona = persona;
            
           
        }
        #endregion

        #region Propiedades

        public clsPersona Persona
        {
            get { return persona; }
        }
       
        #endregion

    }
}
