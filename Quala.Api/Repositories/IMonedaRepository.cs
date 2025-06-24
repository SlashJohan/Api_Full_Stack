using Quala.Api.Models;

namespace Quala.Api.Repositories
{
    public interface IMonedaRepository
    {
        Task<IEnumerable<Moneda>> ObtenerTodasAsync();
    }
}
