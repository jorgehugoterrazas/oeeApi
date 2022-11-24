using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Catalogos.Turnos
{
  public class Turno : BasicAggregateRoot<int>
  {
    public string Nombre { get; set; }
  }
}
