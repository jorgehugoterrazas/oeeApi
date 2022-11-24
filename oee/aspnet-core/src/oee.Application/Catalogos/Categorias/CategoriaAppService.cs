using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Catalogos.Categorias
{
  public class CategoriaAppService : ApplicationService, ICategoriaAppService
  {
    public CategoriaAppService(IRepository<Categoria, int> repositoryCategoria)
    {
      RepositoryCategoria = repositoryCategoria;
    }

    public IRepository<Categoria, int> RepositoryCategoria { get; }

    public async Task<CategoriaDto> CreateAsync(CategoriaDto categoriaDto)
    {
      var categoria = await RepositoryCategoria.InsertAsync(
        new Categoria
        {
          Nombre= categoriaDto.Nombre
        });
      return new CategoriaDto
      {
        Id = categoria.Id,
        Nombre = categoria.Nombre,
        

      };
    }

    public async Task<List<CategoriaDto>> GetListAsync()
    {
      var items = await RepositoryCategoria.GetListAsync();
      return items
          .Select(item => new CategoriaDto
          {
            Id = item.Id,
            Nombre = item.Nombre,
           
          }).ToList();
    }
  }
}
