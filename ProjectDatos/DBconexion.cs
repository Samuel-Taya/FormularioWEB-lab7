using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatos
{
    internal class DBconexion
    {
        public static void Main(string[] args)
        {
            DBconexion db = new DBconexion();
            db.query();
            Console.ReadKey();
        }

        private void query()
        {
            IList<Ciudades> ciudades = DBquery.GetCiudades();

            if (ciudades == null || ciudades.Count == 0)
            {
                Console.WriteLine("No data");
                return;
            }

            foreach (Ciudades city in ciudades)
            {
                Console.WriteLine($"{city.Id}: {city.NombreCiudad}");
            }
        }
    }
}
