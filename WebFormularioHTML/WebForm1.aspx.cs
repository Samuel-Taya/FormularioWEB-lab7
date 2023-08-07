using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Text;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebFormularioHTML.ServiceReference1;
using WebFormularioHTML.ServiceReference2;

namespace WebFormularioHTML // namespace: coleccion de clases
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { //funciones que se cargar al abrir la pagina
            addDropDownCiudadItems();
        }
        /*
        private string[] readFile() //funcion para leer archivos txt
        {
            string[] lines = System.IO.File.ReadAllLines("C:\\Users\\sam_2\\Documents\\CODES\\HTML codes\\ciudades.txt");
            return lines;
        }
        ¨*/
        private string[] serviceCall() //llamada al servicio
        {
            Service1Client client = new Service1Client();
            string[] ciudades = client.GetCiudades();
            return ciudades;
        }
        protected void addDropDownCiudadItems() //funcion que da la lista de ciudades
        {
            //string[] ciudades = readFile();
            //que el leer ciudades sea en el servidor
            string[] ciudades = serviceCall();

            Array.Sort(ciudades);
            DropDownList1.Items.Add("Seleccione una opcion");

            for (int i = 0; i < ciudades.Length; i++)
            {
                string s = ciudades[i];
                DropDownList1.Items.Add(s);
            }
        }
        // Luego toda la info guardarla en la base de datos
        protected void Enviar(object sender, EventArgs e)
        {
            string nombre = this.fname.Text;
            string apellidos = this.lname.Text;
            string sexo = this.male.Checked ? "Masculino" : "Femenino";
            string email = this.mail.Text;
            string direccion = this.adress.Text;
            string ciudad = this.DropDownList1.SelectedValue;
            string requerimiento = this.req.Text;

            IService2 servicio2 = new ServiceReference2.Service2Client();
            servicio2.GuardarInformacion(nombre, apellidos, sexo, email, direccion, ciudad, requerimiento);
        }
    }
}