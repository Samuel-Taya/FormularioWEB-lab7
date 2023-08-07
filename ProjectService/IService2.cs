using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    // Servicio wcf para guardar los datos del del formulario a un sql
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        void GuardarInformacion(string nombre, string apellidos,
            string sexo, string email, string direccion,
            string ciudad, string requerimiento);
    }
}
