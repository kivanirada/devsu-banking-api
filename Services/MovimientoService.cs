using Devsu.DTOs;
using Devsu.Models;
using Devsu.Services;
using Microsoft.EntityFrameworkCore;

public class MovimientoService : IMovimientoService
{
    private readonly AppDbContext _context;

    public MovimientoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Movimiento> CrearMovimientoAsync(MovimientoCreateDto dto)
    {
        var cuenta = await _context.Cuentas.FindAsync(dto.NumeroCuenta);
        if (cuenta == null) throw new Exception("Cuenta no existe");

        if (dto.TipoMovimiento == "Retiro" && cuenta.SaldoInicial < dto.Valor)
            throw new Exception("Saldo insuficiente");

        // Lógica de saldo
        var nuevoSaldo = dto.TipoMovimiento == "Retiro"
            ? cuenta.SaldoInicial - dto.Valor
            : cuenta.SaldoInicial + dto.Valor;

        var movimiento = new Movimiento
        {
            Fecha = DateTime.UtcNow,
            TipoMovimiento = dto.TipoMovimiento,
            Valor = dto.Valor,
            Saldo = nuevoSaldo,
            NumeroCuenta = dto.NumeroCuenta
        };

        cuenta.SaldoInicial = nuevoSaldo;

        _context.Movimientos.Add(movimiento);
        _context.Cuentas.Update(cuenta);
        await _context.SaveChangesAsync();

        return movimiento;
    }

    public async Task<Movimiento> ObtenerMovimientoPorIdAsync(int id)
    {
        return await _context.Movimientos.FindAsync(id);
    }

    public async Task<IEnumerable<Movimiento>> ObtenerMovimientosPorCuentaAsync(int numeroCuenta)
    {
        return await _context.Movimientos
            .Where(m => m.NumeroCuenta == numeroCuenta)
            .OrderByDescending(m => m.Fecha)
            .ToListAsync();
    }

    public async Task<IEnumerable<Movimiento>> ObtenerPorCuentaYFecha(int cuentaId, DateTime desde, DateTime hasta)
    {
        return await _context.Movimientos
            .Where(m => m.NumeroCuenta == cuentaId && m.Fecha >= desde && m.Fecha <= hasta)
            .OrderByDescending(m => m.Fecha)
            .ToListAsync();
    }
}
