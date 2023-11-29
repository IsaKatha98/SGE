using Biblioteca;
using DAL.Conexion;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{
    /// <summary>
    /// Clase que se conecta con una base de datos y devuelve un listado de personas.
    /// </summary>
    public static class clsListadoDepartamentosDAL
    {

        public static List<clsDepartamento> getListadoDepartamentos()
        {
            clsMyConnection conexion = new clsMyConnection();
            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            clsDepartamento oDepartamento;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "Select * from departamentos where id=@id";
                cmd.Connection = conexionAbierta;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oDepartamento = new clsDepartamento();
                        oDepartamento.IdDepartamento = (int)reader["ID"];
                        oDepartamento.Nombre = (string)reader["Nombre"];


                        listadoDepartamentos.Add(oDepartamento);

                    }
                }
                reader.Close();
                conexionAbierta.Close();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoDepartamentos;

        }

        /// <summary>
        /// Método que lee los detalles de una persona.
        /// 
        /// Pre: recibe un id de la persona y un idDepartamento.
        /// Post: 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsDepartamento getDepartamentoById(int id)
        {

            clsMyConnection conexion = new clsMyConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            clsDepartamento oDepartamento = new clsDepartamento();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "Select * from departamentos";
                cmd.Connection = conexionAbierta;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        oDepartamento.IdDepartamento = (int)reader["ID"];
                        oDepartamento.Nombre = (string)reader["Nombre"];




                    }
                }
                reader.Close();
                conexionAbierta.Close();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return oDepartamento;


        }
    }
}
