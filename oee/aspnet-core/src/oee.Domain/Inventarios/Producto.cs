using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Inventarios
{
    public class Producto : BasicAggregateRoot<int>
    {
        public string Nombre { get; set; }
    }
}
