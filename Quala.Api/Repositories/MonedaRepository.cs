using Dapper;
using Quala.Api.Data;
using Quala.Api.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Quala.Api.Repositories
{
    public class MonedaRepository : IMonedaRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public MonedaRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Moneda>> ObtenerTodasAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<Moneda>(
                "SELECT Id, Descripcion FROM JD_mon_Moneda"
            );

            return result;
        }


    }
}
