using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Clientes
{
    public interface IClienteAppService : IApplicationService
    {
        Task<List<ClienteDto>> GetListAsync();
        Task<ClienteDto> CreateAsync(ClienteDto cliente);
        Task DeleteAsync(Guid id);
    }
}
