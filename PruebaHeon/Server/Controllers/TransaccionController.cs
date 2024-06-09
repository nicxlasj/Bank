using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaHeon.Server.Services;
using PruebaHeon.Shared;

namespace PruebaHeon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly TransaccionService _transaccionService;
        public TransaccionController(TransaccionService transaccionService) 
        {
            _transaccionService = transaccionService;
        }
        [HttpGet("{id}")]
        public async Task<List<Transaccion>> GetTransacciones(int id) 
        {
            return await _transaccionService.GetTransacciones(id);
        }
        [HttpGet("formapago")]
        public async Task<List<FormaPago>> GetFormasPago()
        {
            return await _transaccionService.GetFormasPago();
        }
        [HttpGet("banco")]
        public async Task<List<Banco>> GetBancos() 
        {
            return await _transaccionService.GetBancos();
        }

    }
}
