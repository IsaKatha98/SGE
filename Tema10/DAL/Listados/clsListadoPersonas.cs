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



    }
}