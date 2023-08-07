using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {
        public void GuardarInformacion(string nombre, string apellidos, string sexo, string email, string direccion, string ciudad,
                string requerimiento)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Web1DB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO TablaInformacion2 (Nombre, Apellidos, Sexo, Email, Direccion, Ciudad, Requerimiento) " +
                                   "VALUES (@nombre, @apellidos, @sexo, @email, @direccion, @ciudad, @requerimiento)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellidos", apellidos);
                        command.Parameters.AddWithValue("@sexo", sexo);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@direccion", direccion);
                        command.Parameters.AddWithValue("@ciudad", ciudad);
                        command.Parameters.AddWithValue("@requerimiento", requerimiento);
                        command.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                { Console.WriteLine("Error al guardar la información en la base de datos: " + ex.Message); }                                           // Manejo del error en caso de que no se pueda guardar la información

                finally
                { connection.Close(); }
            }
        }
    }
}
