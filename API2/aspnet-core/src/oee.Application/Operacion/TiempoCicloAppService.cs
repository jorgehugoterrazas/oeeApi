using oee.Operaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Operacion
{
  public class TiempoCicloAppService : ApplicationService, ITiempoCicloAppService
  {
    public TiempoCicloAppService(IRepository<TiempoCiclo, int> repositoryTiempoCiclo)
    {
      RepositoryTiempoCiclo = repositoryTiempoCiclo;
    }

    public IRepository<TiempoCiclo, int> RepositoryTiempoCiclo { get; }

    public Task<TiempoCicloDto> CreateAsync(TiempoCicloDto tiempoCicloDto)
    {
      throw new NotImplementedException();
    }

    public async Task<List<TiempoCicloDto>> GetListAsync()
    {
      var items = await RepositoryTiempoCiclo.GetListAsync();
      return items
          .Select(item => new TiempoCicloDto
          {
            Id = item.Id,
            NumerodeParte = item.NumerodeParte,
            Programa = item.Programa,
            TiempoEnSegundos = item.TiempoEnSegundos
          }).ToList();
    }
    public async Task<List<TiempoCicloDto>> GetByNumeroParteAsync(int numeroParte)
    {
      var items = await RepositoryTiempoCiclo.GetListAsync();
      return items
          .Select(item => new TiempoCicloDto
          {
            Id = item.Id,
            NumerodeParte = item.NumerodeParte,
            Programa = item.Programa,
            TiempoEnSegundos = item.TiempoEnSegundos
          }).Where(e => e.NumerodeParte == numeroParte).ToList();
    }
  }
}
