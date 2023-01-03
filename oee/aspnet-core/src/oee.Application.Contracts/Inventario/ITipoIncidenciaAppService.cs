using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Inventario
{
    public interface ITipoIncidenciaAppService : IApplicationService
    {
        Task<List<TipoIncidenciaDto>> GetListAsync();
        Task<TipoIncidenciaDto> CreateAsync(TipoIncidenciaDto tipoIncidencias);
        Task DeleteAsync(int id);
    }
}
