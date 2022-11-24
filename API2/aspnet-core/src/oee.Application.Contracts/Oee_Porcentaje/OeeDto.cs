using System;
using System.Collections.Generic;
using System.Text;

namespace oee.Oee_Porcentaje
{
  public class OeeDto
  {
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string FechaFormato { get; set; }

    public DateTime HoraInicio { get; set; }
    public DateTime HoraFinal { get; set; }

    public string HoraInicioFormato { get; set; }
    public string HoraFinalFormato { get; set; }
    public int TurnoId { get; set; }
    public string Turno { get; set; }
    public string NumeroParte { get; set; }
    public int TotalReales { get; set; }
    public int TotalPlaneadas { get; set; }

    public decimal OE_Porcentaje { get; set; }
    public int GAP_Pzas { get; set; }
    public int GAP_Mins { get; set; }
    public int TiempoMuerto { get; set; }
    public int Programado { get; set; }
    public int DescripcionId { get; set; }
    public string Descripcion { get; set; }
  }
}
