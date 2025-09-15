using Microsoft.AspNetCore.Mvc;
using cp4_net.Interfaces;
using cp4_net.Models.DTOs;
using cp4_net.Services;

namespace cp4_net.Controllers
{
    /// <summary>
    /// Controller para validações geométricas
    /// </summary>
    [ApiController]
    [Route("api/v1/validacoes")]
    [Produces("application/json")]
    public class ValidacoesController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;
        private readonly ILogger<ValidacoesController> _logger;

        /// <summary>
        /// Construtor do controller
        /// </summary>
        /// <param name="calculadoraService">Serviço de cálculos</param>
        /// <param name="logger">Logger</param>
        public ValidacoesController(ICalculadoraService calculadoraService, ILogger<ValidacoesController> logger)
        {
            _calculadoraService = calculadoraService;
            _logger = logger;
        }

        /// <summary>
        /// Verifica se uma forma interna está contida em uma forma externa
        /// </summary>
        /// <param name="request">Dados das formas para verificação</param>
        /// <returns>Resultado da verificação de contenção</returns>
        /// <response code="200">Verificação realizada com sucesso</response>
        /// <response code="400">Dados inválidos fornecidos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost("forma-contida")]
        [ProducesResponseType(typeof(ContencaoResponse), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        public IActionResult VerificarFormaContida([FromBody] ContencaoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var formaExterna = FormaFactory.CriarForma(request.FormaExterna.TipoForma, request.FormaExterna.Parametros);
                var formaInterna = FormaFactory.CriarForma(request.FormaInterna.TipoForma, request.FormaInterna.Parametros);

                var estaContida = _calculadoraService.VerificarContencao(formaExterna, formaInterna);

                var response = new ContencaoResponse
                {
                    EstaContida = estaContida,
                    FormaExterna = request.FormaExterna,
                    FormaInterna = request.FormaInterna,
                    Mensagem = estaContida 
                        ? "A forma interna está contida na forma externa" 
                        : "A forma interna NÃO está contida na forma externa"
                };

                _logger.LogInformation("Verificação de contenção realizada: {EstaContida}", estaContida);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Erro de validação ao verificar contenção: {Message}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno ao verificar contenção");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }
    }

    /// <summary>
    /// DTO para resposta de verificação de contenção
    /// </summary>
    public class ContencaoResponse
    {
        /// <summary>
        /// Indica se a forma interna está contida na externa
        /// </summary>
        public bool EstaContida { get; set; }

        /// <summary>
        /// Forma externa utilizada na verificação
        /// </summary>
        public CalculoRequest FormaExterna { get; set; } = new();

        /// <summary>
        /// Forma interna utilizada na verificação
        /// </summary>
        public CalculoRequest FormaInterna { get; set; } = new();

        /// <summary>
        /// Mensagem descritiva do resultado
        /// </summary>
        public string Mensagem { get; set; } = string.Empty;
    }
}
