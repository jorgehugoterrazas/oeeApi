using System;
using System.Collections.Generic;
using System.Text;

namespace oee.Trazabilidad
{
  public class CorteDto
  {
    public int Id { get; set; }
    public int NumeroEmpleado { get; set; }
    public string Atado { get; set; }
    public DateTime NumeroUnico { get; set; } //fecha inicial
    public DateTime? FechaFinal { get; set; }
    public int? NumeroEmpleadoFinal { get; set; }
    public int? Cantidad { get; set; }
    public int? Rechazos { get; set; }
  }
}
