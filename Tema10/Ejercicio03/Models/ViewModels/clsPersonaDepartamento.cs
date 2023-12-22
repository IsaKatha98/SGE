using Biblioteca;
using BL;

namespace Ejercicio03.Models.ViewModels
{
    //Hereda de persona y hacemos que se traiga un objeto clsDepartamento.
    public class clsPersonaDepartamento : clsPersona
    {
        #region atributos
        clsDepartamento departamento; 
        #endregion

        #region cosntructores
        public clsPersonaDepartamento(clsPersona persona)
        {

            departamento = clsListadoDepartamentosBL.getDepartamentoByIdBL(persona.IdDepartamento);

            //Asociamos las propiedades de esta clase con la del objeto que nos llega.
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Tlf = persona.Tlf;
            this.Direccion=persona.Direccion;
            this.FechaNac=persona.FechaNac;
            this.Id=persona.Id;
            this.IdDepartamento = persona.IdDepartamento;
            this.FotoURL = persona.FotoURL;
            
           
        }
        #endregion

        #region propiedades
        public clsDepartamento Departamento{

            //Solo hay get porque en el VM no se va a poder modificar
            get { return departamento; }
            
        }
        #endregion


    }
}
