using Microsoft.AspNetCore.Mvc;
using PruebaHeon.Server.Services;
using PruebaHeon.Shared;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PruebaHeon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly IConfiguration _config;
        public LoginController(LoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }
        [HttpPost]
        public async Task<IActionResult> GetUsuarios([FromBody] Usuario usuario) 
        { 
             var lstUsers = await _loginService.GetUsuarios(usuario);
            if (lstUsers.Any())
            {
                return Ok(GenerateToken(lstUsers.FirstOrDefault()!));
            }
            return BadRequest(new { Message = "Credenciales invalidas" });
        }
        private string GenerateToken(Usuario usuario) 
        { 
            var claims = new[] {
                new Claim(ClaimTypes.Name, usuario.username!),
                new Claim(ClaimTypes.Role, usuario.rol!)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:key").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
