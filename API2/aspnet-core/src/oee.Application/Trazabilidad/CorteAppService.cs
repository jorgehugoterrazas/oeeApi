using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Trazabilidad
{
  public class CorteAppService : ApplicationService, ICorteAppService
  {
    public IRepository<Corte, int> _repositoryCorte { get; }

    public CorteAppService(IRepository<Corte, int> repositoryCorte)
    {
      _repositoryCorte = repositoryCorte;
    }
    public async Task<CorteDto> CreateAsync(CorteDto corteDto)
    {
      var corte = await _repositoryCorte.InsertAsync(
              new Corte
              {
                NumeroEmpleado = corteDto.NumeroEmpleado,
                Atado = corteDto.Atado,
                NumeroUnico = corteDto.NumeroUnico,
              });
      return new CorteDto
      {
        Id = corte.Id
      };
    }

    public async Task<List<CorteDto>> GetListAsync()
    {
      var items = await _repositoryCorte.GetListAsync();
      return items
          .Select(item => new CorteDto
          {
            Id = item.Id,
            NumeroEmpleado = item.NumeroEmpleado,
            Atado = item.Atado,
          }).ToList();
    }
  }
}
