using Devsu.Dtos;
using Devsu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Devsu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;

        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cuentas = await _cuentaService.ObtenerCuentasAsync();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cuenta = await _cuentaService.ObtenerCuentaPorIdAsync(id);
            if (cuenta == null) return NotFound();
            return Ok(cuenta);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CuentaCreateDto dto)
        {
            var cuenta = new Cuenta
            {
                TipoCuenta = dto.TipoCuenta,
                SaldoInicial = dto.SaldoInicial,
                Estado = dto.Estado,
                ClienteId = dto.ClienteId
            };

            await _cuentaService.CrearCuentaAsync(cuenta);


            return CreatedAtAction(nameof(GetById), new { id = cuenta.NumeroCuenta }, cuenta);

        }


        // Puedes extender con PUT y DELETE si deseas
    }
}
