using oee.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Inventarios
{
    public class TipoIncidenciasAppService : ApplicationService, ITipoIncidenciaAppService
    {
        private readonly IRepository<TipoIncidencia, int> _tipoIncidenciaRepository;

        public TipoIncidenciasAppService(IRepository<TipoIncidencia, int> tipoIncidenciaRepository)
        {
            _tipoIncidenciaRepository = tipoIncidenciaRepository;
        }
        public async Task<TipoIncidenciaDto> CreateAsync(TipoIncidenciaDto tipoIncidencias)
        {
            var todoItem = await _tipoIncidenciaRepository.InsertAsync(
        new TipoIncidencia { Nombre = tipoIncidencias.Nombre }
    );

            return new TipoIncidenciaDto
            {
                Id = todoItem.Id,
                Nombre = todoItem.Nombre
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _tipoIncidenciaRepository.DeleteAsync(id);
        }

        public async Task<List<TipoIncidenciaDto>> GetListAsync()
        {
            var items = await _tipoIncidenciaRepository.GetListAsync();
            return items
                .Select(item => new TipoIncidenciaDto
                {
                    Id = item.Id,
                    Nombre = item.Nombre
                }).ToList();
        }
    }
}
