using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatos
{
    internal class DBquery
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Web1DB;Integrated Security=True";
        public static IList<Ciudades> GetCiudades()
        {
            List<Ciudades> ciudades = new List<Ciudades>();

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                string query = "SELECT Id, Ciudad FROM DataCiudad";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())

                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string nombreCiudad = reader["Ciudad"].ToString();

                            Ciudades ciudad = new Ciudades { Id = id, NombreCiudad = nombreCiudad };
                            ciudades.Add(ciudad);
                        }
                    }
                }
            }
            return ciudades;
        }
    }
}
