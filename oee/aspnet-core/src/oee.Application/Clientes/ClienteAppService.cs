using oee.Inventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace oee.Clientes
{
    public class ClienteAppService : ApplicationService, IClienteAppService
    {
        private readonly IRepository<Cliente, Guid> _clienteRepository;

        public ClienteAppService(IRepository<Cliente, Guid> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<ClienteDto> CreateAsync(ClienteDto cliente)
        {
            var clienteItem = await _clienteRepository.InsertAsync(
        new Cliente
        {
            Colonia = cliente.Colonia,
            Calle = cliente.Calle,
            Contacto = cliente.Contacto,
            Correo = cliente.Correo,
            Municipio = cliente.Municipio,
            Nombre = cliente.Nombre,
            Numero = cliente.Numero,
            Telefono = cliente.Telefono,
            CP = cliente.CP,
            VendedorId= cliente.VendedorId
        }
    );

            return new ClienteDto
            {
                ClienteId = clienteItem.Id,
                Contacto = clienteItem.Contacto,
                CP = clienteItem.CP,
                Telefono = clienteItem.Telefono,
                Calle = clienteItem.Calle,
                Colonia = clienteItem.Colonia,
                Correo = clienteItem.Correo,
                Municipio = clienteItem.Municipio,
                Nombre = clienteItem.Nombre,
                Numero = clienteItem.Numero,
                VendedorId = cliente.VendedorId,

            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _clienteRepository.DeleteAsync(id);

        }

        public async Task<List<ClienteDto>> GetListAsync()
        {
            var items = await _clienteRepository.GetListAsync();

            return items
                .Select(item => new ClienteDto
                {
                    Calle = item.Calle,
                    Colonia = item.Colonia,
                    Contacto = item.Contacto,
                    Correo = item.Correo,
                    Municipio = item.Municipio,
                    Nombre = item.Nombre,
                    Numero = item.Numero,
                    Telefono = item.Telefono,
                    CP = item.CP,
                    VendedorId= item.VendedorId,
                    ClienteId = item.Id
                }).ToList();
        }
    }
}
