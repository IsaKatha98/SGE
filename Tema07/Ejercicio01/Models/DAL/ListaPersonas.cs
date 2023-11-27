namespace Ejercicio01.Models.DAL
{
    public static class ListaPersonas
    {
        /// <summary>
        /// Función que devuelve una lista de personas.
        /// 
        /// Pre: no hay.
        /// Post: no hay.
        /// </summary>
        /// <returns>listado de personas</returns>
        public static List<clsPersona> listadoPersonas ()
        {
            
            List<clsPersona> listadoPersonas = new List<clsPersona>() {
                new clsPersona("Fernando", "Miguel"),
                new clsPersona("Isabel", "Katharina"),
                new clsPersona("Isaac","Ramos")
                };

            throw new Exception();
            return listadoPersonas;

            
        
        }
    }
}
