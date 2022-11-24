using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace oee.Catalogos.Categorias
{
  public class Categoria : BasicAggregateRoot<int>
  {
    public string Nombre { get; set; }
  }
}
