using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Captura
{
  public class Oee : BasicAggregateRoot<int>
  {
    public DateTime Fecha { get; set; }

    public DateTime HoraInicio { get; set; }
    public DateTime HoraFinal { get; set; }
    public int TurnoId { get; set; }
    public string NumeroParte { get; set; }
    public int TotalReales {get;set;}
    public int TotalPlaneadas { get; set; }

    public decimal OE_Porcentaje { get; set; }
    public int GAP_Pzas { get; set; }
    public int GAP_Mins { get; set; }
    public int TiempoMuerto { get; set; }
    public int Programado { get; set; }
    public int DescripcionId { get; set; }

  }
}
