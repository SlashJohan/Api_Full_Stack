using Quala.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quala.Api.Repositories
{
    public interface ISucursalRepository
    {
        Task<int> InsertarSucursalAsync(Sucursal sucursal);
        Task<IEnumerable<Sucursal>> ObtenerSucursalesAsync();
        Task<Sucursal?> ObtenerSucursalPorIdAsync(int codigo);
        Task<bool> ActualizarSucursalAsync(Sucursal sucursal);
        Task<bool> EliminarSucursalAsync(int codigo);
    }
}
