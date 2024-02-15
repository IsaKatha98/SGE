using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{
    public class clsListadoModelosDAl
    {
        public static List<clsModelos> getListadoModelosDAL()
        {
            clsConnection conexion = new clsConnection();
            List<clsModelos> listadoModelos = new List<clsModelos>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "Select * from modelos";
                cmd.Connection = conexionAbierta;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clsModelos oModelo = new clsModelos();
                        oModelo.IdModelo = (int)reader["idModelo"];
                        oModelo.IdMarca = (int)reader["idMarca"];
                        oModelo.Nombre = (string)reader["nombre"];
                        oModelo.Precio = (int)reader["precio"];


                        listadoModelos.Add(oModelo);

                    }
                }
                reader.Close();
                conexionAbierta.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoModelos;

        }


        public static List<clsModelos> getListadoModelosByIdMarcaDAL(int id)
        {
            clsConnection conexion = new clsConnection();
            List<clsModelos> listadoModelosByIdMarca = new List<clsModelos>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.CommandText = "Select * from modelos where idMarca=@id";
                cmd.Connection = conexionAbierta;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clsModelos oModelo = new clsModelos();
                        oModelo.IdModelo = (int)reader["idModelo"];
                        oModelo.IdMarca = (int)reader["idMarca"];
                        oModelo.Nombre = (string)reader["nombre"];
                        oModelo.Precio = (int)reader["precio"];


                        listadoModelosByIdMarca.Add(oModelo);

                    }
                }
                reader.Close();
                conexionAbierta.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoModelosByIdMarca;
        }
    }
}
