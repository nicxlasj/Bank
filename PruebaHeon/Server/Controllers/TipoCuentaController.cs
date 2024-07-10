using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using PruebaHeon.Shared;
using Microsoft.AspNetCore.Authorization;

namespace PruebaHeon.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCuentaController : ControllerBase
    {
        private string _connectionString;
        public TipoCuentaController(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("dbConnection")!;
        }
        [HttpGet]
        public async Task<List<TipoCuenta>> GetTipoCuentas() 
        {
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "SELECT * FROM TipoCuenta"};
            using var db = new SqlConnection(_connectionString);
            var result = await db.QueryAsync<TipoCuenta>(scriptSQL.scriptText);
            return result.ToList();

        } 
    }
}
