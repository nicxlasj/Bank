using Dapper;
using PruebaHeon.Shared;
using System.Data.SqlClient;

namespace PruebaHeon.Server.Services
{
    public class ClientesService
    {
        private string _connectionString;
        public ClientesService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("dbConnection")!;
        }

        public async Task<List<Cliente>> GetClientes(int? id) 
        {
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "[dbo].[SpGetClientes]", parameters = new { id = id } };
            using var db = new SqlConnection(_connectionString);
            var result = await db.QueryAsync<Cliente>(scriptSQL.scriptText, scriptSQL.parameters);
            return result.ToList();
        }
        public async Task<Cliente> SaveCliente(Cliente cliente)
        {
            ScriptSQL scriptSQL = new ScriptSQL { scriptText = "[dbo].[SpSaveClientes]", parameters = new { id = cliente.id, idTipoIdentificacion = cliente.idTipoIdentificacion, idTipoPersona = cliente.idTipoPersona, nombres = cliente.nombres, apellidos = cliente.apellidos, identificacion = cliente.identificacion, telefono = cliente.telefono } };
            using var db = new SqlConnection(_connectionString);

            var result = await db.QueryAsync<Cliente>(scriptSQL.scriptText, scriptSQL.parameters);
            return result.SingleOrDefault()!;

        }
    }
}
