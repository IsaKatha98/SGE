using Entidades;

namespace DAL
{
    public class clsListadoDepartamentosDAL
    {

        /// <summary>
        /// Función que nos devuelve un listado de todos los departamentos de la empresa
        /// </summary>
        /// <returns>Listado de departamentos</returns>
        public static List<clsDepartamento> ListadoCompletoDepartamentosDAL()
        {

            List<clsDepartamento> listadoDepartamentos;


            listadoDepartamentos = new List<clsDepartamento>
            {
                new clsDepartamento(1, "Gaming y Videojuegos"),
                new clsDepartamento(2, "Comercial"),
                new clsDepartamento(3, "MAWI")
            };



            return listadoDepartamentos;


        }

        /// <summary>
        /// Función estática que busca un departamneto por su ID
        /// Pre: el Id del departametno debe ser un Id que exista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsDepartamento departamentoPorId(int id)
        {
            clsDepartamento depEncontrado = new clsDepartamento();

            List<clsDepartamento> listadoDepartamentos;


            listadoDepartamentos = new List<clsDepartamento>
            {
                new clsDepartamento(1, "Gaming y Videojuegos"),
                new clsDepartamento(2, "Comercial"),
                new clsDepartamento(3, "MAWI")
            };
            depEncontrado = listadoDepartamentos.Find(x => x.Id == id);
            return depEncontrado;
        }
    }
}
