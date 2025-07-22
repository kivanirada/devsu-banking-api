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


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CuentaCreateDto dto)
        {
            var cuenta = await _cuentaService.ObtenerCuentaPorIdAsync(id);
            if (cuenta == null)
                return NotFound();

            cuenta.TipoCuenta = dto.TipoCuenta;
            cuenta.SaldoInicial = dto.SaldoInicial;
            cuenta.Estado = dto.Estado;
            cuenta.ClienteId = dto.ClienteId;

            await _cuentaService.ActualizarCuentaAsync(cuenta);

            return Ok(cuenta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cuenta = await _cuentaService.ObtenerCuentaPorIdAsync(id);
            if (cuenta == null) return NotFound();

            await _cuentaService.EliminarCuentaAsync(id);
            return NoContent();
        }

    }
}
