using Devsu.DTOs;
using Devsu.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devsu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearMovimiento([FromBody] MovimientoCreateDto movimiento)
        {
            try
            {
                var resultado = await _movimientoService.CrearMovimientoAsync(movimiento);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = resultado.MovimientoId }, resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpGet("cuenta/{numeroCuenta}")]
        public async Task<IActionResult> ObtenerPorCuenta(int numeroCuenta)
        {
            var movimientos = await _movimientoService.ObtenerMovimientosPorCuentaAsync(numeroCuenta);
            return Ok(movimientos);
        }

        [HttpGet("cuenta/{numeroCuenta}/rango")]
        public async Task<IActionResult> ObtenerPorFecha(int numeroCuenta, DateTime inicio, DateTime fin)
        {
            var movimientos = await _movimientoService.ObtenerPorCuentaYFecha(numeroCuenta, inicio, fin);
            return Ok(movimientos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var movimiento = await _movimientoService.ObtenerMovimientoPorIdAsync(id);
            if (movimiento == null)
                return NotFound();
            return Ok(movimiento);
        }
    }
}
