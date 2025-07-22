namespace Devsu.Models
{
    public interface ICuentaService
    {
        Task<Cuenta> CrearCuentaAsync(Cuenta cuenta);
        Task<IEnumerable<Cuenta>> ObtenerCuentasAsync();
        Task<Cuenta> ObtenerCuentaPorIdAsync(int numeroCuenta);
    }
}
