using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    // Servicio WCF
    public class Service1 : IService1
    {
        public IList<string> GetCiudades()
        {
            IList<string> ciudades = new List<string>();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Web1DB;Integrated Security=True"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                                                                  
                    string query = "SELECT Ciudad FROM DataCiudad";                                         

                    using (SqlCommand command = new SqlCommand(query, connection))                          
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())                                                           
                            {
                                string nombreCiudad = reader["Ciudad"].ToString();
                                ciudades.Add(nombreCiudad);
                            }
                        }
                    }
                }
                catch (Exception ex)
                { Console.WriteLine("Error al obtener ciudades desde la base de datos: " + ex.Message); }       
                finally
                { connection.Close(); }      
            }
            return ciudades;
        }
    }
}
