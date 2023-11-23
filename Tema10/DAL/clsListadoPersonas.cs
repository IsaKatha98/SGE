using Microsoft.Data.SqlClient;
using Biblioteca;

namespace DAL
{
    public class clsListadoPersonas
    {
        public static List<clsPersona> getListadoPersonas() {

            SqlConnection conexion = new SqlConnection();
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona;

            conexion.ConnectionString
            = "server=107-24\\SQLEXPRESS;database=Persona;uid=prueba;pwd=123;trustServerCertificate=true";

            try
            {

                conexion.Open();

                cmd.CommandText = "Select * from personas";
                cmd.Connection = conexion;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.IdPersona = (int)reader["ID"];
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
                conexion.Close();


            } catch (SqlException ex){
                throw ex;
            }

            return listadoPersonas;

        }
     

        
    }
}