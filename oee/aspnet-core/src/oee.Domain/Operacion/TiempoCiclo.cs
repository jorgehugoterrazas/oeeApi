using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Operacion
{
  public class TiempoCiclo : BasicAggregateRoot<int>
  {
   public int NumerodeParte { get;set; }
  public string Programa { get;set; }
  public int TiempoEnSegundos { get;set; }

  }
}
