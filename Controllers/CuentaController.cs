using AppBanco.AccessData.Repository;
using AppBanco.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppBanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        /// <summary>
        /// Registra una nueva cuenta bancaria.
        /// </summary>
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarCuenta([FromBody] Cuenta cuenta)
        {
            await _cuentaRepository.RegistrarCuentaAsync(cuenta);
            return Ok(new { mensaje = "Cuenta registrada correctamente" });
        }

        /// <summary>
        /// Realiza un depósito en la cuenta.
        /// </summary>
        [HttpPost("deposito")]
        public async Task<IActionResult> Deposito([FromQuery] string nroCuenta, [FromQuery] decimal importe)
        {
            await _cuentaRepository.DepositoAsync(nroCuenta, importe);
            return Ok(new { mensaje = "Depósito realizado correctamente" });
        }

        /// <summary>
        /// Realiza un retiro de la cuenta.
        /// </summary>
        [HttpPost("retiro")]
        public async Task<IActionResult> Retiro([FromQuery] string nroCuenta, [FromQuery] decimal importe)
        {
            await _cuentaRepository.RetiroAsync(nroCuenta, importe);
            return Ok(new { mensaje = "Retiro realizado correctamente" });
        }

        /// <summary>
        /// Realiza una transferencia entre cuentas.
        /// </summary>
        [HttpPost("transferencia")]
        public async Task<IActionResult> Transferencia([FromQuery] string cuentaOrigen, [FromQuery] string cuentaDestino, [FromQuery] decimal importe)
        {
            await _cuentaRepository.TransferenciaAsync(cuentaOrigen, cuentaDestino, importe);
            return Ok(new { mensaje = "Transferencia realizada correctamente" });
        }

        /// <summary>
        /// Consulta el saldo de una cuenta.
        /// </summary>
        [HttpGet("saldo/{nroCuenta}")]
        public async Task<IActionResult> ConsultarSaldo(string nroCuenta)
        {
            var saldo = await _cuentaRepository.ConsultarSaldoAsync(nroCuenta);
            return Ok(new { nroCuenta, saldo });
        }
    }
}
