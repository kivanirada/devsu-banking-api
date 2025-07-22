using Devsu.Models;
using Microsoft.EntityFrameworkCore;

public class CuentaService : ICuentaService
{
    private readonly AppDbContext _context; // Usa el nombre real de tu DbContext

    public CuentaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cuenta> CrearCuentaAsync(Cuenta cuenta)
    {
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();
        return cuenta;
    }

    public async Task<IEnumerable<Cuenta>> ObtenerCuentasAsync()
    {
        return await _context.Cuentas.ToListAsync();
    }

    public async Task<Cuenta> ObtenerCuentaPorIdAsync(int numeroCuenta)
    {
        return await _context.Cuentas.FindAsync(numeroCuenta);
    }

    public async Task ActualizarCuentaAsync(Cuenta cuenta)
    {
        _context.Cuentas.Update(cuenta);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarCuentaAsync(int numeroCuenta)
    {
        var cuenta = await _context.Cuentas.FindAsync(numeroCuenta);
        if (cuenta != null)
        {
            _context.Cuentas.Remove(cuenta);
            await _context.SaveChangesAsync();
        }
    }

}
