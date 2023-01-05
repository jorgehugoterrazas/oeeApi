using oee.Clientes;
using oee.Inventario;
using oee.Inventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Productos
{
    public class ProductoAppService : ApplicationService, IProductoAppService
    {
        private readonly IRepository<Producto, int> _repository;

        public ProductoAppService(IRepository<Producto, int> repository)
        {
            _repository = repository;
        }
        public async Task<ProductoDto> CreateAsync(ProductoDto producto)
        {
            var todoItem = await _repository.InsertAsync(
                new Producto { Nombre = producto.Nombre }
            );

            return new ProductoDto
            {
                Id = todoItem.Id,
                Nombre = todoItem.Nombre
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ProductoDto>> GetListAsync()
        {
            var items = await _repository.GetListAsync();
            return items
                .Select(item => new ProductoDto
                {
                    Id = item.Id,
                    Nombre = item.Nombre
                }).ToList();
        }
    }
}
