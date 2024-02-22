using Entidades;

namespace DAL
{
    public class clsListadoPersonasDAL
    {

        /// <summary>
        /// Función que nos devuelve un listado de todas las personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<clsPersona> ListadoCompletoPersonasDAL()
        {

            List<clsPersona> listadoPersonas;
           
            listadoPersonas = new List<clsPersona>
            {
                new clsPersona(1, "Luisa", "Cardozo", new DateTime(2006, 8, 4), "Su casa", "666767676","wwwroot/images/crying.jpg", 2),
                new clsPersona(2, "Pedro", "Cornejo", new DateTime(2009, 11, 2), "Mi casa", "666767676", "wwwroot/images/crying.jpg", 1),
                new clsPersona(3, "Matías", "Ditaranto", new DateTime(2010, 12, 3), "Su casa", "666767676", "wwwroot/images/crying.jpg", 3),
                new clsPersona(4, "Marcos", "Domínguez", new DateTime(2011, 3, 16), "Mi casa", "666767676", "wwwroot/images/crying.jpg", 1),
                new clsPersona(5, "Miguel", "Domínguez", new DateTime(2007, 5, 22), "Su casa", "666767676", "wwwroot/images/crying.jpg", 2),
                new clsPersona(6, "Pedro", "Gallardo", new DateTime(2008, 6, 2), "Mi casa", "666767676", "wwwroot/images/crying.jpg", 3),
                new clsPersona(7, "Juan Manuel ", "Gallego", new DateTime(2006, 7, 19), "Su casa", "666767676", "wwwroot/images/crying.jpg", 4),
                new clsPersona(8, "Isaac", "García", new DateTime(2012, 11, 29), "Mi casa", "666767676", "wwwroot/images/crying.jpg", 2)
            };
           
            return listadoPersonas;

        }



        /// <summary>
        /// Función estática que busca una persona por su ID
        /// Pre: el Id de la persona debe ser un Id que exista
        /// </summary>
        /// <param name="id">id de la persona</param>
        /// <returns></returns>
        public static clsPersona personaPorId(int id)
        {
            clsPersona persEncontrada = new clsPersona();

            List<clsPersona> listadoPersonas;


            listadoPersonas = new List<clsPersona>
            {
                new clsPersona(1, "Luisa", "Cardozo", new DateTime(2006, 8, 4), "Su casa", "666767676", "", 2),
                new clsPersona(2, "Pedro", "Cornejo", new DateTime(1973, 6, 2), "Mi casa", "666767676", "", 1),
                new clsPersona(3, "Matías", "Ditaranto", new DateTime(1973, 6, 2), "Su casa", "666767676", "", 3),
                new clsPersona(4, "Marcos", "Domínguez", new DateTime(1973, 6, 2), "Mi casa", "666767676", "", 1),
                new clsPersona(5, "Miguel", "Domínguez", new DateTime(1973, 6, 2), "Su casa", "666767676", "", 2),
                new clsPersona(6, "Pedro", "Gallardo", new DateTime(1973, 6, 2), "Mi casa", "666767676", "", 3),
                new clsPersona(7, "Juan Manuel ", "Gallego", new DateTime(1973, 6, 2), "Su casa", "666767676", "", 4),
                new clsPersona(8, "Isaac", "García", new DateTime(1973, 6, 2), "Mi casa", "666767676", "", 2)
            };
            persEncontrada = listadoPersonas.Find(x => x.Id == id);
            return persEncontrada;
        }
    }
}
