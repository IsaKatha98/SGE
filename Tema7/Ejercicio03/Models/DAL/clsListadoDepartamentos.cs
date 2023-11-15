using Ejercicio03.Models.Entities;


namespace Ejercicio03.Models.DAL

{
    public class clsListadoDepartamentos
    {
        //Nos creamos una función de tipo lista de clsPersona
        public static List<clsDepartamento> listadoDept()
        {

            List<clsDepartamento> dept = new List<clsDepartamento>()
        {
            new clsDepartamento() {IdDepartamento=1, NombreDepartamento="Ventas"},
            new clsDepartamento() {IdDepartamento=2, NombreDepartamento="Marketing"},
            new clsDepartamento() {IdDepartamento=3, NombreDepartamento="Producción"}

        };

            return dept;

        }
    }
}
