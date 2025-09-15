using System.ComponentModel.DataAnnotations;

namespace cp4_net.Models.DTOs
{
    /// <summary>
    /// DTO para requisições de verificação de contenção
    /// </summary>
    public class ContencaoRequest
    {
        /// <summary>
        /// Forma externa (que deve conter a outra)
        /// </summary>
        [Required(ErrorMessage = "A forma externa é obrigatória")]
        public CalculoRequest FormaExterna { get; set; } = new();

        /// <summary>
        /// Forma interna (que deve estar contida)
        /// </summary>
        [Required(ErrorMessage = "A forma interna é obrigatória")]
        public CalculoRequest FormaInterna { get; set; } = new();
    }
}
