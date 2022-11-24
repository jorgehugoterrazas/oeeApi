using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Catalogos.DescripcionFallas
{
  public interface IDescripcionFallaAppService : IApplicationService
  {
    Task<List<DescripcionFallaDto>> GetListAsync();
    Task<DescripcionFallaDto> CreateAsync(DescripcionFallaDto descripcionFalla);
    //Task DeleteAsync(Guid id);
  }
}
