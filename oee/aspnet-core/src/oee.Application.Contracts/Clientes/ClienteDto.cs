using System;
using System.Collections.Generic;
using System.Text;

namespace oee.Clientes
{
    public class ClienteDto
    {
        public Guid ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string CP { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int VendedorId { get; set; }

    }
}
