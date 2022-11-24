using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Trazabilidad
{
  public class UsuarioAppService : ApplicationService, IUsuarioAppService
  {
    public IRepository<Usuario, int> _repository { get; }

    public UsuarioAppService(IRepository<Usuario, int> repository)
    {
      _repository = repository;
    }
    public async Task<UsuarioDto> CreateAsync(UsuarioDto usuarioDto)
    {
      var usuario = await _repository.InsertAsync(
              new Usuario
              {
                NumeroEmpleado = usuarioDto.NumeroEmpleado,
                Nombres = usuarioDto.Nombres,
                ApellidoPaterno = usuarioDto.ApellidoPaterno,
                ApellidoMaterno = usuarioDto.ApellidoMaterno,

              });
      return new UsuarioDto
      {
        Id = usuario.Id
      };
    }

    public async Task<List<UsuarioDto>> GetListAsync()
    {
      var items = await _repository.GetListAsync();
      return items
          .Select(item => new UsuarioDto
          {
            Id = item.Id,
            NumeroEmpleado = item.NumeroEmpleado,
            Nombres = item.Nombres + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno
          }).ToList();
    }

    public async Task<UsuarioDto> GetUsuarioAsync(int id)
    {
      var usuarios = await _repository.GetListAsync();
      var items = usuarios.Where(x => x.NumeroEmpleado == id).FirstOrDefault();
      var usuarioDto = new UsuarioDto()
      {
        Id = items.Id,
        NumeroEmpleado = items.NumeroEmpleado,
        Nombres = items.Nombres + " " + items.ApellidoPaterno + " " + items.ApellidoMaterno
      };
      return usuarioDto;
    }

    
  }
}
