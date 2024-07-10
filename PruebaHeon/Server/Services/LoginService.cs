using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Dapper;
using System.Data.SqlClient;
using PruebaHeon.Shared;

namespace PruebaHeon.Server.Services
{
    public class LoginService
    {
        private readonly string  _connectionString;
        public LoginService(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("dbConnection")!;
        }

        public async Task<List<Usuario>> GetUsuarios(Usuario usuario) 
        {
            using var db = new SqlConnection(_connectionString);
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "[dbo].[SpGetUsuarios]", parameters = new { username = usuario.username, password = usuario.password } };
            var result = await db.QueryAsync<Usuario>(scriptSQL.scriptText, scriptSQL.parameters);
            return result.ToList();
            
        }
        

    }
}
