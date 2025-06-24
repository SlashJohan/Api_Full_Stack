namespace Quala.Api.Dtos.SucursalDto
{
    public class SucursalResponseDto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Identificacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public int MonedaId { get; set; }
    }
}
