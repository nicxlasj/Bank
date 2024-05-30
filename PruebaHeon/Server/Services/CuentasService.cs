using PruebaHeon.Shared;
using Dapper;
using System.Data.SqlClient;

namespace PruebaHeon.Server.Services
{
    public class CuentasService
    {
        private string _connectionString;
        public CuentasService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("dbConnection")!;
        }
        public async Task<List<Cuenta>> GetCuentas(int? id)
        {
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "[dbo].[SpGetCuentas]", parameters = new { id = id } };
            using var db = new SqlConnection(_connectionString);
            var result = await db.QueryAsync<Cuenta>(scriptSQL.scriptText, scriptSQL.parameters);
            return result.ToList();
        }
        public async Task SaveCuenta(Cuenta cuenta) 
        {
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "[dbo].[SpSaveCuenta]", parameters = new 
            { 
                id = cuenta.id,
                idCliente = cuenta.idCliente,
                idTipoCuenta = cuenta.idTipoCuenta,
                numeroCuenta = cuenta.numeroCuenta,
                saldo = cuenta.saldo
            } };
            using var db = new SqlConnection(_connectionString);
            var result = await db.QueryAsync<Cuenta>(scriptSQL.scriptText, scriptSQL.parameters);
        }

    }
}
