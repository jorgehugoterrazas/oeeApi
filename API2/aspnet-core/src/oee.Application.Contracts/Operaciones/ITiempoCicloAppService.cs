using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Operaciones
{
  public interface ITiempoCicloAppService : IApplicationService
  {
    Task<List<TiempoCicloDto>> GetListAsync();
    Task<TiempoCicloDto> CreateAsync(TiempoCicloDto tiempoCicloDto);
  }
}
