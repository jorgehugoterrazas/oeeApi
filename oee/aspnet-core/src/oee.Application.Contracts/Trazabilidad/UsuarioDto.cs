using System;
using System.Collections.Generic;
using System.Text;

namespace oee.Trazabilidad
{
  public class UsuarioDto
  {
    public int Id { get; set; }
    public long NumeroEmpleado { get; set; }
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
  }
}
