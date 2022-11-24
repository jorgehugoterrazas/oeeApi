using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Trazabilidad
{
  public class Usuario : BasicAggregateRoot<int>
  {
    public long NumeroEmpleado { get; set; }
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }

  }
}
