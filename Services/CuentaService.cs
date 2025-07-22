namespace Devsu.Models
{
    public class CuentaService : ICuentaService
    {
        private readonly IGenericRepository<Cuenta> _repo;

        public CuentaService(IGenericRepository<Cuenta> repo)
        {
            _repo = repo;
        }

        public async Task<Cuenta> CrearCuentaAsync(Cuenta cuenta)
        {
            return await _repo.AddAsync(cuenta);
        }

        public async Task<IEnumerable<Cuenta>> ObtenerCuentasAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Cuenta> ObtenerCuentaPorIdAsync(int numeroCuenta)
        {
            return await _repo.GetByIdAsync(numeroCuenta);
        }
    }
}
