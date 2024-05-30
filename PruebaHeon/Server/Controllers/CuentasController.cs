using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaHeon.Server.Services;
using PruebaHeon.Shared;

namespace PruebaHeon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly CuentasService _cuentasService;
        public CuentasController(CuentasService cuentasService) 
        {
            _cuentasService = cuentasService;
        }
        [HttpGet("{id}")]
        public async Task<List<Cuenta>> GetCuentas(int id) 
        {
            return await _cuentasService.GetCuentas(id);
        }
        [HttpPost]
        public async Task SaveCuenta([FromBody] Cuenta cuenta) 
        { 
           await _cuentasService.SaveCuenta(cuenta);
        }
    }
}
