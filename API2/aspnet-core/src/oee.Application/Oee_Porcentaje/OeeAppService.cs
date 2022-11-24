using oee.Captura;
using oee.Catalogos.DescripcionFallas;
using oee.Catalogos.Turnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Oee_Porcentaje
{
  public class OeeAppService : ApplicationService, IOeeAppService
  {
    public OeeAppService(IRepository<Oee, int> repositoryOee, IRepository<DescripcionFalla, int> repositoryDescripcion, IRepository<Turno, int> repositoryTurno)
    {
      RepositoryOee = repositoryOee;
      RepositoryDescripcion = repositoryDescripcion;
      RepositoryTurno = repositoryTurno;
    }

    public IRepository<Oee, int> RepositoryOee { get; }
    public IRepository<DescripcionFalla, int> RepositoryDescripcion { get; }
    public IRepository<Turno, int> RepositoryTurno { get; }

    public async Task<OeeDto> CreateAsync(OeeDto oeeDto)
    {
      var oee = await RepositoryOee.InsertAsync(
              new Oee
              {
                DescripcionId = oeeDto.DescripcionId,
                Fecha = oeeDto.Fecha,
                GAP_Mins = oeeDto.GAP_Mins,
                GAP_Pzas = oeeDto.GAP_Pzas,
                HoraFinal = oeeDto.HoraFinal.AddHours(-6),
                HoraInicio = oeeDto.HoraInicio.AddHours(-6),
                NumeroParte = oeeDto.NumeroParte,
                OE_Porcentaje = oeeDto.OE_Porcentaje,
                Programado = oeeDto.Programado,
                TiempoMuerto = oeeDto.TiempoMuerto,
                TotalReales = oeeDto.TotalReales,
                TurnoId = oeeDto.TurnoId,
                TotalPlaneadas = oeeDto.TotalPlaneadas,
              });
      return new OeeDto
      {
        Id = oee.Id,
      };
    }

    public async Task<List<OeeDto>> GetListAsync()
    {
      var items = await RepositoryOee.GetListAsync();
      var descripciones = await RepositoryDescripcion.GetListAsync();
      var turnos = await RepositoryTurno.GetListAsync();
      return items
          .Select(item => new OeeDto
          {
            Id = item.Id,
            TurnoId = item.TurnoId,
            TotalReales = item.TotalReales,
            TiempoMuerto = item.TiempoMuerto,
            Programado = item.Programado,
            OE_Porcentaje = item.OE_Porcentaje,
            NumeroParte = item.NumeroParte,
            HoraInicioFormato = item.HoraInicio.ToShortTimeString(),
            HoraFinalFormato = item.HoraFinal.ToShortTimeString(),
            DescripcionId = item.DescripcionId,
            FechaFormato = item.Fecha.ToShortDateString(),
            GAP_Mins = item.GAP_Mins,
            GAP_Pzas = item.GAP_Pzas,
            TotalPlaneadas = item.TotalPlaneadas,
            Descripcion = descripciones.Where(x => x.Id == item.DescripcionId).FirstOrDefault() == null ? "" : descripciones.Where(x => x.Id == item.DescripcionId).FirstOrDefault().Modo,
            Turno = turnos.Where(x => x.Id == item.TurnoId).FirstOrDefault() == null ? "" : turnos.Where(x => x.Id == item.TurnoId).FirstOrDefault().Nombre
          }).ToList();
    }
  }
}
