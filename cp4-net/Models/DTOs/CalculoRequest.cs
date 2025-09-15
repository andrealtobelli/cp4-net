using System.ComponentModel.DataAnnotations;

namespace cp4_net.Models.DTOs
{
    /// <summary>
    /// DTO para requisições de cálculo
    /// </summary>
    public class CalculoRequest
    {
        /// <summary>
        /// Tipo da forma geométrica
        /// </summary>
        [Required(ErrorMessage = "O tipo da forma é obrigatório")]
        public string TipoForma { get; set; } = string.Empty;

        /// <summary>
        /// Parâmetros da forma (raio, largura, altura, etc.)
        /// </summary>
        [Required(ErrorMessage = "Os parâmetros da forma são obrigatórios")]
        public Dictionary<string, double> Parametros { get; set; } = new();
    }
}
