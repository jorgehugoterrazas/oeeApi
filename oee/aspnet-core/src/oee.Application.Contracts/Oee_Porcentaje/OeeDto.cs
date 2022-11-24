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
    public string Area { get; set; }
    public string DescripcionFTQ { get; set; }
    public int Ftq { get; set; }
    public string DescripcionTM { get; set; }
    public double? Availability_Porcentaje { get; set; }
    public double? Quality_Porcentaje { get; set; }
    public double? Performance_Porcentaje { get; set; }
    public double? Oee_Porcentaje { get; set; }
    public int? NetoTime { get; set; }
    public int? NetoTimeNP { get; set; }
    public int? NetoTimeNP_Performance { get; set; }
    public int TiempoCiclo { get; set; }
    public int Asociados { get; set; }
  }
}
