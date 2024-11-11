using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUDWebForms.Modelo
{
    public class Conexion
    {
        private readonly SqlConnection con;
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        public class Producto
        {
            public int codigo { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public string marca { get; set; }
            public double precio { get; set; }
            public int stock { get; set; }
        }

        

        private void conectar()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void desconectar()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand comando = new SqlCommand("SELECT * FROM Productos", con))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto
                                {
                                    codigo = (int)reader["codigo"],
                                    nombre = reader["nombre"].ToString(),
                                    descripcion = reader["descripcion"].ToString(),
                                    marca = reader["marca"].ToString(),
                                    precio = (int)reader["precio"],
                                    stock = (int)reader["stock"]
                                };
                                productos.Add(producto);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return productos;
        }

    }
}
