using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace oee.Trazabilidad
{
  public interface IUsuarioAppService
  {
    Task<List<UsuarioDto>> GetListAsync();
    Task<UsuarioDto> CreateAsync(UsuarioDto usuarioDto);
    Task<UsuarioDto> GetUsuarioAsync(int id);
  }
}
