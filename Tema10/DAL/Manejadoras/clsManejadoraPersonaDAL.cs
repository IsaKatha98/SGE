using Biblioteca;
using DAL.Conexion;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadoras
{
    public static class clsManejadoraPersonaDAL
    {
        
       /// <summary>
       /// Método que borra un registro de la tabla Personas
       /// 
       /// Precondición: int idPersona
       /// Postcondición: int numeroFilasAfectadas
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public static int deletePersonaDAL (int id)
        {
            int numeroFilasAfectadas = 0;

            clsMyConnection conexion = new clsMyConnection();
            SqlCommand cmd = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "DELETE FROM Personas WHERE ID=@id";
                cmd.Connection = conexionAbierta;
                numeroFilasAfectadas = cmd.ExecuteNonQuery();

                //Cerramos la conexión
                conexionAbierta.Close();
            
            } catch (Exception ex)
            {
                throw ex;
            }

           
            return numeroFilasAfectadas;


        }

        /// <summary>
        /// Método que actualiza el idDepartamento al que pertenece una persona.
        /// 
        /// Pre: recibe un id de la persona y un idDepartamento.
        /// Post: devuelve un número de filas actualizadas.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public static int updatePersonaDAL (int id, int idDepartamento)
        {
            int numeroFilasAfectadas = 0;

            clsMyConnection conexion = new clsMyConnection();
            SqlCommand cmd = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = idDepartamento;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "UPDATE Personas SET IDDepartamento=@idDepartamento WHERE ID=@id";
                cmd.Connection = conexionAbierta;
                numeroFilasAfectadas = cmd.ExecuteNonQuery();

                //Cerramos la conexión
                conexionAbierta.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return numeroFilasAfectadas;
        

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
            clsPersona oPersona= new clsPersona();

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

        /// <summary>
        /// Método que inserta una persona nueva en la tabla Personas.
        /// 
        /// Pre:
        /// Post: devuelve la variable numeroFilasAfectadas.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="tlf"></param>
        /// <param name="direccion"></param>
        /// <param name="foto"></param>
        /// <param name="fechaNac"></param>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public static int insertPersonaDAL (int id, string nombre, string apellidos, string tlf, string direccion, string foto, DateTime fechaNac, int idDepartamento)
        {

            int numeroFilasAfectadas = 0;

            clsMyConnection conexion = new clsMyConnection();
            SqlCommand cmd = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar,30).Value = nombre;
            cmd.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar,60).Value = apellidos;
            cmd.Parameters.Add("@tlf", System.Data.SqlDbType.VarChar, 15).Value = tlf;
            cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar, 60).Value = direccion;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarChar, 255).Value = foto;
            cmd.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = fechaNac;
            cmd.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = idDepartamento;
            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "INSERT INTO Personas(ID, Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento)" +
                    "values (@id, @nombre, @apellidos, @tlf, @direccion, @foto, @fechaNac,@idDepartamento)";
                cmd.Connection = conexionAbierta;
                numeroFilasAfectadas = cmd.ExecuteNonQuery();

                //Cerramos la conexión
                conexionAbierta.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return numeroFilasAfectadas;

        }

      
    }
}
