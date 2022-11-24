using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Trazabilidad
{
  public class Corte : BasicAggregateRoot<int>
  {
    public int NumeroEmpleado { get; set; }
    public string Atado { get; set; }
    public DateTime NumeroUnico { get; set; } //fecha inicial
    public DateTime? FechaFinal { get; set; }
    public int? NumeroEmpleadoFinal { get; set; }
    public int? Cantidad { get; set; }
    public int? Rechazos { get; set; }


  }
}
