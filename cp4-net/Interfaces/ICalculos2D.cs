namespace cp4_net.Interfaces
{
    /// <summary>
    /// Interface para cálculos de formas geométricas 2D
    /// </summary>
    public interface ICalculos2D
    {
        /// <summary>
        /// Calcula a área da forma geométrica
        /// </summary>
        /// <returns>Área da forma</returns>
        double CalcularArea();

        /// <summary>
        /// Calcula o perímetro da forma geométrica
        /// </summary>
        /// <returns>Perímetro da forma</returns>
        double CalcularPerimetro();
    }
}
