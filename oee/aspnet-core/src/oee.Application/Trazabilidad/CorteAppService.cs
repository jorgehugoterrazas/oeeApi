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
    public IRepository<Usuario, int> _repositoryUsuario { get; }

    public CorteAppService(IRepository<Corte, int> repositoryCorte, IRepository<Usuario, int> repositoryUsuario)
    {
      _repositoryCorte = repositoryCorte;
      _repositoryUsuario = repositoryUsuario;
    }
    public async Task<CorteDto> CreateAsync(CorteDto corteDto)
    {
      var corte = await _repositoryCorte.InsertAsync(
              new Corte
              {
                NumeroEmpleado = corteDto.NumeroEmpleado,
                Atado = corteDto.Atado,
                NumeroUnico = corteDto.NumeroUnico.AddHours(-6),
                Maquina = corteDto.Maquina,
                NumeroParte = corteDto.NumeroParte,
                Cantidad = corteDto.Cantidad,
                Rechazos = corteDto.Rechazos,
                Subensamble = corteDto.Subensamble
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
            NumeroUnico = item.NumeroUnico
          }).ToList();
    }

    public async Task<Corte> GetByIdAsync(int id)
    {
      var items = await _repositoryCorte.GetAsync(id);
      return items;
    }

    public async Task<CorteDto> UpdateAsync(CorteDto corteDto)
    {
      var corte = await this.GetByIdAsync(corteDto.Id);
      corte.FechaFinal = corteDto.FechaFinal;
      corte.NumeroEmpleadoFinal = corteDto.NumeroEmpleadoFinal;
      corte.Cantidad = corteDto.Cantidad;
      corte.Rechazos = corteDto.Rechazos;
      corte.Subensamble = corteDto.Subensamble;
      var corteUpdate = await _repositoryCorte.UpdateAsync(corte);
      return new CorteDto
      {
        Id = corte.Id
      };
    }

    public async Task<List<CorteDto>> GetNumeroUnicoAsync(int NumeroEmpleado)
    {
      var items = await _repositoryCorte.GetListAsync();
      
      var list = items.Where(x => x.NumeroEmpleado == NumeroEmpleado)
          .Select(item => new CorteDto
          {

            NumeroUnicoFormato = item.NumeroUnico.ToString("yyMMddHHmm"),
            Id = item.Id,
            NumeroEmpleado = item.NumeroEmpleado,
            Atado = item.Atado,
            NumeroUnico = item.NumeroUnico,
          }).ToList();
      return list;
    }
    public async Task<CorteDto> GetDetalleAsync(int id,string atado)
    {
      var corteList = await _repositoryCorte.GetListAsync();
      var items = corteList.Where(x => x.NumeroEmpleado == id && x.Atado == atado ).LastOrDefault();
      var usuarioList = await _repositoryUsuario.GetListAsync();
      var usuario = usuarioList.Where(x => x.NumeroEmpleado == id).FirstOrDefault();
      var corte = new CorteDto()
      {
        Id = items.Id,
        NumeroEmpleado = items.NumeroEmpleado,
        Atado = items.Atado,
        NumeroUnico=items.NumeroUnico,
        NumeroUnicoFormato = items.NumeroUnico.ToString("yyMMddHHmm"),
        NombreOperador = usuario.Nombres + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno,
        Cantidad = items.Cantidad,
        Rechazos = items.Rechazos,
        Maquina = items.Maquina,
        NumeroParte = items.NumeroParte,
        Subensamble = items.Subensamble
      };
      return corte;
    }

  }
}
