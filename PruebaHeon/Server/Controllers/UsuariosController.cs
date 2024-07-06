using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaHeon.Server.Services;
using PruebaHeon.Shared;
using System.Runtime.CompilerServices;

namespace PruebaHeon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly LoginService _loginService;
        public UsuariosController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<List<Usuario>> GetUsuarios([FromBody] Usuario usuario) 
        { 
            return await _loginService.GetUsuarios(usuario);
        }
    }
}
