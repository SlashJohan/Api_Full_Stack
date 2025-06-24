using Dapper;
using System.Data;
using Quala.Api.Models;
using Quala.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quala.Api.Repositories
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public SucursalRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // Repositories/SucursalRepository.cs
        public async Task<int> InsertarSucursalAsync(Sucursal sucursal)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(
                "JD_usp_InsertarSucursal",
                new
                {
                    sucursal.Descripcion,
                    sucursal.Direccion,
                    sucursal.Identificacion,
                    sucursal.FechaCreacion,
                    sucursal.MonedaId
                },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<IEnumerable<Sucursal>> ObtenerSucursalesAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = await connection.QueryAsync<Sucursal>(
                "JD_usp_ObtenerSucursales",
                commandType: CommandType.StoredProcedure
            );
            return result;
        }

        public async Task<Sucursal?> ObtenerSucursalPorIdAsync(int codigo)
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<Sucursal>(
                "JD_usp_ObtenerSucursalPorId",
                new { Codigo = codigo },
                commandType: CommandType.StoredProcedure
            );
            return result;
        }

        public async Task<bool> ActualizarSucursalAsync(Sucursal sucursal)
        {
            using var connection = _connectionFactory.CreateConnection();
            var affectedRows = await connection.ExecuteAsync(
                "JD_usp_ActualizarSucursal",
                new
                {
                    sucursal.Codigo,
                    sucursal.Descripcion,
                    sucursal.Direccion,
                    sucursal.Identificacion,
                    sucursal.FechaCreacion,
                    sucursal.MonedaId
                },
                commandType: CommandType.StoredProcedure
            );
            return affectedRows > 0;
        }

        public async Task<bool> EliminarSucursalAsync(int codigo)
        {
            using var connection = _connectionFactory.CreateConnection();
            var affectedRows = await connection.ExecuteAsync(
                "JD_usp_EliminarSucursal",
                new { Codigo = codigo },
                commandType: CommandType.StoredProcedure
            );
            return affectedRows > 0;
        }
    }
}
