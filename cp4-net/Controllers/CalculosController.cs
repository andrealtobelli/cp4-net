using Microsoft.AspNetCore.Mvc;
using cp4_net.Interfaces;
using cp4_net.Models.DTOs;
using cp4_net.Services;
using System.ComponentModel.DataAnnotations;

namespace cp4_net.Controllers
{
    /// <summary>
    /// Controller para cálculos geométricos
    /// </summary>
    [ApiController]
    [Route("api/v1/calculos")]
    [Produces("application/json")]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;
        private readonly ILogger<CalculosController> _logger;

        /// <summary>
        /// Construtor do controller
        /// </summary>
        /// <param name="calculadoraService">Serviço de cálculos</param>
        /// <param name="logger">Logger</param>
        public CalculosController(ICalculadoraService calculadoraService, ILogger<CalculosController> logger)
        {
            _calculadoraService = calculadoraService;
            _logger = logger;
        }

        /// <summary>
        /// Calcula a área de uma forma geométrica
        /// </summary>
        /// <param name="request">Dados da forma para cálculo</param>
        /// <returns>Resultado do cálculo da área</returns>
        /// <response code="200">Cálculo realizado com sucesso</response>
        /// <response code="400">Dados inválidos fornecidos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost("area")]
        [ProducesResponseType(typeof(CalculoResponse), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        public IActionResult CalcularArea([FromBody] CalculoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var forma = FormaFactory.CriarForma(request.TipoForma, request.Parametros);
                var resultado = _calculadoraService.CalcularArea(forma);

                var response = new CalculoResponse
                {
                    Resultado = Math.Round(resultado, 2),
                    TipoCalculo = "area",
                    TipoForma = request.TipoForma,
                    Parametros = request.Parametros
                };

                _logger.LogInformation("Área calculada para {TipoForma}: {Resultado}", request.TipoForma, resultado);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Erro de validação ao calcular área: {Message}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno ao calcular área");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Calcula o perímetro de uma forma geométrica
        /// </summary>
        /// <param name="request">Dados da forma para cálculo</param>
        /// <returns>Resultado do cálculo do perímetro</returns>
        /// <response code="200">Cálculo realizado com sucesso</response>
        /// <response code="400">Dados inválidos fornecidos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost("perimetro")]
        [ProducesResponseType(typeof(CalculoResponse), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        public IActionResult CalcularPerimetro([FromBody] CalculoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var forma = FormaFactory.CriarForma(request.TipoForma, request.Parametros);
                var resultado = _calculadoraService.CalcularPerimetro(forma);

                var response = new CalculoResponse
                {
                    Resultado = Math.Round(resultado, 2),
                    TipoCalculo = "perimetro",
                    TipoForma = request.TipoForma,
                    Parametros = request.Parametros
                };

                _logger.LogInformation("Perímetro calculado para {TipoForma}: {Resultado}", request.TipoForma, resultado);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Erro de validação ao calcular perímetro: {Message}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno ao calcular perímetro");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Calcula o volume de uma forma geométrica 3D
        /// </summary>
        /// <param name="request">Dados da forma para cálculo</param>
        /// <returns>Resultado do cálculo do volume</returns>
        /// <response code="200">Cálculo realizado com sucesso</response>
        /// <response code="400">Dados inválidos fornecidos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost("volume")]
        [ProducesResponseType(typeof(CalculoResponse), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        public IActionResult CalcularVolume([FromBody] CalculoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var forma = FormaFactory.CriarForma(request.TipoForma, request.Parametros);
                var resultado = _calculadoraService.CalcularVolume(forma);

                var response = new CalculoResponse
                {
                    Resultado = Math.Round(resultado, 2),
                    TipoCalculo = "volume",
                    TipoForma = request.TipoForma,
                    Parametros = request.Parametros
                };

                _logger.LogInformation("Volume calculado para {TipoForma}: {Resultado}", request.TipoForma, resultado);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Erro de validação ao calcular volume: {Message}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno ao calcular volume");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Calcula a área superficial de uma forma geométrica 3D
        /// </summary>
        /// <param name="request">Dados da forma para cálculo</param>
        /// <returns>Resultado do cálculo da área superficial</returns>
        /// <response code="200">Cálculo realizado com sucesso</response>
        /// <response code="400">Dados inválidos fornecidos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost("area-superficial")]
        [ProducesResponseType(typeof(CalculoResponse), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        public IActionResult CalcularAreaSuperficial([FromBody] CalculoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var forma = FormaFactory.CriarForma(request.TipoForma, request.Parametros);
                var resultado = _calculadoraService.CalcularAreaSuperficial(forma);

                var response = new CalculoResponse
                {
                    Resultado = Math.Round(resultado, 2),
                    TipoCalculo = "area-superficial",
                    TipoForma = request.TipoForma,
                    Parametros = request.Parametros
                };

                _logger.LogInformation("Área superficial calculada para {TipoForma}: {Resultado}", request.TipoForma, resultado);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Erro de validação ao calcular área superficial: {Message}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno ao calcular área superficial");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }
    }
}
