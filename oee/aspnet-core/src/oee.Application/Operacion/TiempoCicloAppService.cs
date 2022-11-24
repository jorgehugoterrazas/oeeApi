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

    public async Task<TiempoCicloDto> CreateAsync(TiempoCicloDto tiempoCicloDto)
    {
      var pieza = await RepositoryTiempoCiclo.InsertAsync(
        new TiempoCiclo
        {
          NumerodeParte=tiempoCicloDto.NumerodeParte,
          Programa=tiempoCicloDto.Programa,
          TiempoEnSegundos = tiempoCicloDto.TiempoEnSegundos
        });

      return new TiempoCicloDto
      {
        Id = pieza.Id,
        NumerodeParte = tiempoCicloDto.NumerodeParte,
        TiempoEnSegundos=tiempoCicloDto.TiempoEnSegundos,
        Programa=pieza.Programa,
      };
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
    public async Task<List<TiempoCicloDto>> GetListDistinctAsync()
    {
      var items = await RepositoryTiempoCiclo.GetListAsync();
      return items
          .Select(item => new TiempoCicloDto
          {
            Id = item.Id,
            NumerodeParte = item.NumerodeParte,
            Programa = item.Programa,
            TiempoEnSegundos = item.TiempoEnSegundos
          }).DistinctBy(x => x.Programa).OrderBy(x => x.Programa).ToList();
    }
  }
}
