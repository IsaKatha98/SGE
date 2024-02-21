using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;

namespace DAL.Manejadoras
{
    public class clsHandlerPersonaDAL
    {
        /// <summary>
        /// Método que borra un registro de la tabla Personas
        /// 
        /// Precondición: int idPersona
        /// Postcondición: int numeroFilasAfectadas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int deletePersonaDAL(int id)
        {
            int numeroFilasAfectadas = 0;

            clsConexion conexion = new clsConexion();
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

            }
            catch (Exception ex)
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
        public static int updatePersonaDAL(clsPersona persona)
        {
            int numeroFilasAfectadas = 0;

            clsConexion conexion = new clsConexion();
            SqlCommand cmd = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 30).Value = persona.Nombre;
            cmd.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar, 60).Value = persona.Apellidos;
            cmd.Parameters.Add("@tlf", System.Data.SqlDbType.VarChar, 15).Value = persona.Tlf;
            cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar, 60).Value = persona.Direccion;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarChar, 255).Value = persona.FotoURL;
            cmd.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.FechaNac;
            cmd.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "UPDATE Personas SET Nombre=@nombre, Apellidos=@apellidos, Telefono=@tlf, Direccion=@direccion," +
                    "Foto=@foto, FechaNacimiento=@fechaNac, IDDepartamento=@idDepartamento WHERE ID=@id";
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
        public static int insertPersonaDAL(clsPersona persona)
        {

            int numeroFilasAfectadas = 0;

            clsConexion conexion = new clsConexion();
            SqlCommand cmd = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 30).Value = persona.Nombre;
            cmd.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar, 60).Value = persona.Apellidos;
            cmd.Parameters.Add("@tlf", System.Data.SqlDbType.VarChar, 15).Value = persona.Tlf;
            cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar, 60).Value = persona.Direccion;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarChar, 255).Value = persona.FotoURL;
            cmd.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.FechaNac;
            cmd.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "INSERT INTO Personas(Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento)" +
                    "values (@nombre, @apellidos, @tlf, @direccion, @foto, @fechaNac,@idDepartamento)";
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
