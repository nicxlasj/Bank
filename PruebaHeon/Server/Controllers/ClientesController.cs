using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaHeon.Server.Services;
using PruebaHeon.Shared;

namespace PruebaHeon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;
        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }
        [HttpGet]
        public async Task<List<Cliente>> GetClientes() 
        {
            return await _clientesService.GetClientes(null);
        }
        [HttpGet("{id}")]
        
        public async Task<List<Cliente>> GetCliente(int id)
        {
            return await _clientesService.GetClientes(id);
        }
    }
}
