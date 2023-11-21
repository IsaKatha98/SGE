using MandalorianoB.Entidades;

namespace MandalorianoB.DAL
{
    public class clsListadoMisionesDAL
    {
        //Creamos una constructor que devuelva una lista de tipo clsMision
        public static List<clsMision> listadoMisiones()
        {
            //Nos creamos la lista de tipo clsMision
            List<clsMision> misiones = new List<clsMision>()
            {
                new clsMision(1, "Rescate de Baby Yoda", "Debes hacerte con Grogu y llevçarselo a Luke Skywalker para su entrenamiento", 5000),
                new clsMision(2, "Recuperar armadura Beskar", "Tu armadura Beskar ha sido robada.Debes encontrarla",2000),
                new clsMision(3, "Planeta Sorgon", "Debes llevar a un niño de vuelta a su planeta natal, Sorgon", 500),
                new clsMision(4, "Renacuajos", "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos",500)

            };

            return misiones;
        }
    }
}

   
