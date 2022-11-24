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
    public string NumeroUnicoFormato { get; set; }
    public DateTime? FechaFinal { get; set; }
    public int? NumeroEmpleadoFinal { get; set; }
    public int? Cantidad { get; set; }
    public int? Rechazos { get; set; }
    public string NombreOperador { get; set; }
    public string Maquina { get; set; }
    public int? NumeroParte { get; set; }
    public string Subensamble { get; set; }

  }
}
