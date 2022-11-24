using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Catalogos.DescripcionFallas
{
  public class DescripcionFallaAppService : ApplicationService, IDescripcionFallaAppService
  {
    private readonly IRepository<DescripcionFalla, int> _descripcionFallaRepository;

    public DescripcionFallaAppService(IRepository<DescripcionFalla, int> descripcionFallaRepository)
    {
      _descripcionFallaRepository = descripcionFallaRepository;
    }
    public async Task<DescripcionFallaDto> CreateAsync(DescripcionFallaDto descripcionFalla)
    {
      var descripcionFallo = await _descripcionFallaRepository.InsertAsync(
        new DescripcionFalla
        {
          CategoriaId = descripcionFalla.CategoriaId,
          Modo = descripcionFalla.Modo
        });
      return new DescripcionFallaDto
      {
        Id = descripcionFallo.Id,
        Modo = descripcionFallo.Modo,
        CategoriaId = descripcionFallo.CategoriaId,
      
      };
    }

    public async Task<List<DescripcionFallaDto>> GetListAsync()
    {
      var items = await _descripcionFallaRepository.GetListAsync();
      return items
          .Select(item => new DescripcionFallaDto
          {
            Id = item.Id,
            CategoriaId = item.CategoriaId,
            Modo = item.Modo,
          }).ToList();
    }
  }
}
