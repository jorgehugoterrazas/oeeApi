using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Catalogos.Turnos
{
  public interface ITurnoAppService : IApplicationService
  {
    Task<List<TurnoDto>> GetListAsync();
    Task<TurnoDto> CreateAsync(TurnoDto turnoDto);
  }
}
