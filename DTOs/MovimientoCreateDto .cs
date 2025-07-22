namespace Devsu.DTOs
{
    public class MovimientoCreateDto
    {
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public int NumeroCuenta { get; set; }
    }
}
