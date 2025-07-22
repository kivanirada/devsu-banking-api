
using Devsu.DTOs;

namespace Devsu.Services
{
    using Devsu.Models;

    public interface IMovimientoService
    {
        Task<Movimiento> CrearMovimientoAsync(MovimientoCreateDto dto);
        Task<Movimiento> ObtenerMovimientoPorIdAsync(int id);
        Task<IEnumerable<Movimiento>> ObtenerMovimientosPorCuentaAsync(int numeroCuenta);
        Task<IEnumerable<Movimiento>> ObtenerPorCuentaYFecha(int cuentaId, DateTime desde, DateTime hasta);
    }

}



