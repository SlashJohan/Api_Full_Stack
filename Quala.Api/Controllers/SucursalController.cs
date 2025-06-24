using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quala.Api.Models;
using Quala.Api.Repositories;
using Quala.Api.Dtos.SucursalDto;

namespace Quala.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalRepository _sucursalRepository;

        public SucursalController(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        // GET: api/sucursal
        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var sucursales = await _sucursalRepository.ObtenerSucursalesAsync();
            var response = sucursales.Select(s => new SucursalResponseDto
            {
                Codigo = s.Codigo,
                Descripcion = s.Descripcion,
                Direccion = s.Direccion,
                Identificacion = s.Identificacion,
                FechaCreacion = s.FechaCreacion,
                MonedaId = s.MonedaId
            });

            return Ok(response);
        }

        // GET: api/sucursal/{codigo}
        [HttpGet("{codigo}")]
        public async Task<IActionResult> ObtenerPorId(int codigo)
        {
            var s = await _sucursalRepository.ObtenerSucursalPorIdAsync(codigo);
            if (s == null)
                return NotFound();

            var dto = new SucursalResponseDto
            {
                Codigo = s.Codigo,
                Descripcion = s.Descripcion,
                Direccion = s.Direccion,
                Identificacion = s.Identificacion,
                FechaCreacion = s.FechaCreacion,
                MonedaId = s.MonedaId
            };

            return Ok(dto);
        }

        // POST: api/sucursal
        [HttpPost]
        public async Task<IActionResult> CrearSucursal([FromBody] SucursalCreateDto dto)
        {
            var sucursal = new Sucursal
            {
                Descripcion = dto.Descripcion,
                Direccion = dto.Direccion,
                Identificacion = dto.Identificacion,
                FechaCreacion = dto.FechaCreacion,
                MonedaId = dto.MonedaId
            };

            var id = await _sucursalRepository.InsertarSucursalAsync(sucursal);
            return Ok(new { message = "Sucursal creada correctamente ✅", id });
        }

        // PUT: api/sucursal/{codigo}
        [HttpPut("{codigo}")]
        public async Task<IActionResult> Actualizar(int codigo, [FromBody] SucursalUpdateDto dto)
        {
            var existente = await _sucursalRepository.ObtenerSucursalPorIdAsync(codigo);
            if (existente == null)
                return NotFound();

            var sucursal = new Sucursal
            {
                Codigo = codigo,
                Descripcion = dto.Descripcion,
                Direccion = dto.Direccion,
                Identificacion = dto.Identificacion,
                FechaCreacion = dto.FechaCreacion,
                MonedaId = dto.MonedaId
            };

            var actualizado = await _sucursalRepository.ActualizarSucursalAsync(sucursal);
            return actualizado ? NoContent() : StatusCode(500, "Error al actualizar");
        }

        // DELETE: api/sucursal/{codigo}
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Eliminar(int codigo)
        {
            var eliminado = await _sucursalRepository.EliminarSucursalAsync(codigo);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
