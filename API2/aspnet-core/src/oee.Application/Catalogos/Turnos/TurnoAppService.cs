using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Catalogos.Turnos
{
  public class TurnoAppService : ApplicationService, ITurnoAppService
  {
    public TurnoAppService(IRepository<Turno, int> repositoryTurno)
    {
      RepositoryTurno = repositoryTurno;
    }

    public IRepository<Turno, int> RepositoryTurno { get; }

    public async Task<TurnoDto> CreateAsync(TurnoDto turnoDto)
    {
      var turno = await RepositoryTurno.InsertAsync(
              new Turno
              {
                Nombre = turnoDto.Nombre
              });
      return new TurnoDto
      {
        Id = turno.Id,
        Nombre = turno.Nombre,


      };
    }

    public async Task<List<TurnoDto>> GetListAsync()
    {
      var items = await RepositoryTurno.GetListAsync();
      return items
          .Select(item => new TurnoDto
          {
            Id = item.Id,
            Nombre = item.Nombre,

          }).ToList();
    }
  }
}
