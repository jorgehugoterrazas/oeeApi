using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Trazabilidad
{
  public interface ICorteAppService : IApplicationService
  {
    Task<List<CorteDto>> GetListAsync();
    Task<CorteDto> CreateAsync(CorteDto tiempoCicloDto);
  }
}
