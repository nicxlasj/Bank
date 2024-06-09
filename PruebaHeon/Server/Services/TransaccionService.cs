using PruebaHeon.Shared;
using Dapper;
using System.Data.SqlClient;

namespace PruebaHeon.Server.Services
{
    public class TransaccionService
    {
        private string _connectionString;
        public TransaccionService(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("dbConnection")!;
        }
        public async Task<List<Transaccion>> GetTransacciones(int? id)
        {
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "[dbo].[SpGetTransaccion]", parameters = new { id = id } };
            using var db = new SqlConnection(_connectionString);
            var result = await db.QueryAsync<Transaccion>(scriptSQL.scriptText, scriptSQL.parameters);
            return result.ToList();
        }
        public async Task<List<FormaPago>> GetFormasPago()
        {
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "SELECT * FROM FormaPago" };
            using var db = new SqlConnection(_connectionString);
            var result = await db.QueryAsync<FormaPago>(scriptSQL.scriptText);
            return result.ToList();
        }

        public async Task<List<Banco>> GetBancos()
        {
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "SELECT * FROM Banco" };
            using var db = new SqlConnection(_connectionString);
            var result = await db.QueryAsync<Banco>(scriptSQL.scriptText);
            return result.ToList();
        }

    }
}
