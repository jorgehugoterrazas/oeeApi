using oee.Clientes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Productos
{
    public interface IProductoAppService : IApplicationService
    {
        Task<List<ProductoDto>> GetListAsync();
        Task<ProductoDto> CreateAsync(ProductoDto producto);
        Task DeleteAsync(int id);
    }
}
