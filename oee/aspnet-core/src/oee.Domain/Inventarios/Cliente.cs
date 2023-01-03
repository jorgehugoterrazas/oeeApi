using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Inventarios
{
    public class Cliente : BasicAggregateRoot<Guid>
    {
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
