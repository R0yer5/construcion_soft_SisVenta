﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; //Driver de SQL Server
using System.Data; //Buffer de memorias
using System.Configuration; //Estraer la cadena de conexion de la CPW
using CapaEntidad;

namespace CapaNegocio
{
    public class ClienteBL : Interface.ICliente
    {
        //Extraer la cadena de conexion
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public DataTable Listar()
        {
            using(SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TCliente";
                //Llevar la consulta a la BD y traer los  registros de la tabla 
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }
        public bool Actualizar(Cliente cliente)
        {
            //throw new NotImplementedException();
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "UPDATE TCliente SET Apellidos = @Apellidos, Nombres = @Nombres, Direccion = @Direccion WHERE CodCliente = @CodCliente";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@CodCliente", cliente.CodCliente);
                comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                try
                {
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (SqlException ex)
                {
                    // Manejar la excepción de la base de datos
                    Console.WriteLine("Error al actualizar el registro del cliente: " + ex.Message);
                    return false;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public bool Agregar(Cliente cliente)
        {
            //throw new NotImplementedException();
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "insert into TCliente values(@CodCliente,@Apellidos,@Nombres,@Direccion)";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@CodCliente", cliente.CodCliente);
                comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public DataTable Buscar(string codCliente)
        {
            using(SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TCliente where CodCliente = @codCliente";
                SqlCommand comando = new SqlCommand(consulta,conexion);
                comando.Parameters.AddWithValue("@CodCliente", codCliente);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }

        }

        public bool Eliminar(string codCliente)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    string consulta = "delete from TCliente where CodCliente = @CodCliente";
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    comando.Parameters.AddWithValue("@CodCliente", codCliente);
                    conexion.Open();
                    int i = Convert.ToInt32(comando.ExecuteNonQuery());
                    conexion.Close();
                    if (i == 1) return true;
                    else return false;

                }
            }
            catch
            {
                return false;
            }
            
                    
        }

    }
}
