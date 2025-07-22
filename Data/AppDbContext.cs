using Microsoft.EntityFrameworkCore;
using Devsu.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Persona> Personas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Movimiento> Movimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Herencia TPH: Cliente hereda de Persona
        modelBuilder.Entity<Persona>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Persona>("Persona")
            .HasValue<Cliente>("Cliente");

        modelBuilder.Entity<Cuenta>()
            .HasKey(c => c.NumeroCuenta);

        modelBuilder.Entity<Cuenta>()
            .HasOne(c => c.Cliente)
            .WithMany(c => c.Cuentas)
            .HasForeignKey(c => c.ClienteId);

        modelBuilder.Entity<Cuenta>()
            .Property(c => c.SaldoInicial)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Movimiento>()
            .HasKey(m => m.MovimientoId);

        modelBuilder.Entity<Movimiento>()
            .HasOne(m => m.Cuenta)
            .WithMany(c => c.Movimientos)
            .HasForeignKey(m => m.NumeroCuenta);

        modelBuilder.Entity<Movimiento>()
            .Property(m => m.Saldo)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Movimiento>()
            .Property(m => m.Valor)
            .HasPrecision(18, 2);

    }
}
