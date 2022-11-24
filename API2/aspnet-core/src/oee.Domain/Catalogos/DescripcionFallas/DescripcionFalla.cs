using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Catalogos.DescripcionFallas
{
  public class DescripcionFalla : BasicAggregateRoot<int>
  {
    public string Modo { get; set; }
    public int CategoriaId { get; set; }
  }
}
