using Microsoft.AspNetCore.Mvc;
using Quala.Api.Repositories;
using Quala.Api.Dtos.MonedasDto;
using System.Linq;
using System.Threading.Tasks;

namespace Quala.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaRepository _monedaRepository;

        public MonedaController(IMonedaRepository monedaRepository)
        {
            _monedaRepository = monedaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var monedas = await _monedaRepository.ObtenerTodasAsync();

            var resultado = monedas.Select(m => new MonedaResponseDto
            {
                Id = m.Id,
                Descripcion = m.Descripcion
            });

            return Ok(resultado);
        }
    }
}
