using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Oee_Porcentaje
{
  public interface IOeeAppService : IApplicationService
  {
    Task<List<OeeDto>> GetListAsync();
    Task<OeeDto> CreateAsync(OeeDto oeeDto);
  }
}
