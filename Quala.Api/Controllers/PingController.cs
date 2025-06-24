using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quala.Api.Data;
using System;

namespace Quala.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        private readonly SqlConnectionFactory _factory;

        public PingController(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public IActionResult PingDb()
        {
            try
            {
                using var conn = _factory.CreateConnection();
                conn.Open();
                return Ok("✅ Conexión a SQL Server exitosa.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Error de conexión: {ex.Message}");
            }
        }

        // 🔐 Endpoint protegido por JWT
        [Authorize]
        [HttpGet("protegido")]
        public IActionResult Protegido()
        {
            return Ok("🔒 JWT válido: acceso autorizado.");
        }
    }
}
