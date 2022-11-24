using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace oee.Catalogos.Categorias
{
  public interface ICategoriaAppService : IApplicationService
  {
    Task<List<CategoriaDto>> GetListAsync();
    Task<CategoriaDto> CreateAsync(CategoriaDto categoriaDto);
  }
}
