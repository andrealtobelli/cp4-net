namespace cp4_net.Interfaces
{
    /// <summary>
    /// Interface para cálculos de formas geométricas 3D
    /// </summary>
    public interface ICalculos3D
    {
        /// <summary>
        /// Calcula o volume da forma geométrica
        /// </summary>
        /// <returns>Volume da forma</returns>
        double CalcularVolume();

        /// <summary>
        /// Calcula a área superficial da forma geométrica
        /// </summary>
        /// <returns>Área superficial da forma</returns>
        double CalcularAreaSuperficial();
    }
}
