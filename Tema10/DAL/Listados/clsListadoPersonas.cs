using Microsoft.Data.SqlClient;
using Biblioteca;
using DAL.Conexion;

namespace DAL.Listados
{
    /// <summary>
    /// Clase que se conecta con una base de datos y devuelve un listado de personas.
    /// </summary>
    public class clsListadoPersonas
    {
        public static List<clsPersona> getListadoPersonas()
        {

            clsMyConnection conexion = new clsMyConnection();
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona;

           

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection  conexionAbierta=conexion.getConnection();

                cmd.CommandText = "Select * from personas";
                cmd.Connection = conexionAbierta;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.Id = (int)reader["ID"];
                        oPersona.Nombre = (string)reader["Nombre"];
                        oPersona.Apellidos = (string)reader["Apellidos"];
                        oPersona.Tlf = (string)reader["Telefono"];
                        oPersona.Direccion = (string)reader["Direccion"];
                        oPersona.FotoURL = (string)reader["Foto"];
                        oPersona.FechaNac = (DateTime)reader["FechaNacimiento"];
                        oPersona.IdDepartamento = (int)reader["IDDepartamento"];

                        listadoPersonas.Add(oPersona);

                    }
                }
                reader.Close();
                conexionAbierta.Close();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoPersonas;

        }
        /// <summary>
        /// Método que lee los detalles de una persona.
        /// 
        /// Pre: recibe un id de la persona y un idDepartamento.
        /// Post: 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsPersona readDetailsPersonaDAL(int id)
        {

            clsMyConnection conexion = new clsMyConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona = new clsPersona();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "Select * from Personas WHERE ID=@id";
                cmd.Connection = conexionAbierta;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        oPersona.Id = (int)reader["ID"];
                        oPersona.Nombre = (string)reader["Nombre"];
                        oPersona.Apellidos = (string)reader["Apellidos"];
                        oPersona.Tlf = (string)reader["Telefono"];
                        oPersona.Direccion = (string)reader["Direccion"];
                        oPersona.FotoURL = (string)reader["Foto"];
                        oPersona.FechaNac = (DateTime)reader["FechaNacimiento"];
                        oPersona.IdDepartamento = (int)reader["IDDepartamento"];

                    }
                }
                reader.Close();
                //Cerramos la conexión
                conexionAbierta.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return oPersona;


        }



    }
}