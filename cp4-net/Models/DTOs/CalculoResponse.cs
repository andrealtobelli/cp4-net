namespace cp4_net.Models.DTOs
{
    /// <summary>
    /// DTO para respostas de cálculo
    /// </summary>
    public class CalculoResponse
    {
        /// <summary>
        /// Resultado do cálculo
        /// </summary>
        public double Resultado { get; set; }

        /// <summary>
        /// Tipo de cálculo realizado
        /// </summary>
        public string TipoCalculo { get; set; } = string.Empty;

        /// <summary>
        /// Tipo da forma utilizada
        /// </summary>
        public string TipoForma { get; set; } = string.Empty;

        /// <summary>
        /// Parâmetros utilizados no cálculo
        /// </summary>
        public Dictionary<string, double> Parametros { get; set; } = new();
    }
}
