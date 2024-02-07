using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{
    public static class clsListadoMarcasDAL
    {
        public static List<clsMarcas> getListadoMarcasDAL()
        {
            clsConnection conexion = new clsConnection();
            List<clsMarcas> listadoMarcas = new List<clsMarcas>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.getConnection();

                cmd.CommandText = "Select * from marcas";
                cmd.Connection = conexionAbierta;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clsMarcas oMarca = new clsMarcas();
                        oMarca.IdMarca = (int)reader["idMarca"];
                        oMarca.Nombre = (string)reader["nombre"];


                        listadoMarcas.Add(oMarca);

                    }
                }
                reader.Close();
                conexionAbierta.Close();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoMarcas;

        }
    
    }
}
