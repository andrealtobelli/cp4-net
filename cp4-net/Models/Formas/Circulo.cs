using cp4_net.Interfaces;

namespace cp4_net.Models.Formas
{
    /// <summary>
    /// Representa um círculo com cálculos de área e perímetro
    /// </summary>
    public class Circulo : ICalculos2D
    {
        /// <summary>
        /// Raio do círculo
        /// </summary>
        public double Raio { get; set; }

        /// <summary>
        /// Construtor do círculo
        /// </summary>
        /// <param name="raio">Raio do círculo</param>
        public Circulo(double raio)
        {
            Raio = raio;
        }

        /// <summary>
        /// Calcula a área do círculo (π * r²)
        /// </summary>
        /// <returns>Área do círculo</returns>
        public double CalcularArea()
        {
            return Math.PI * Raio * Raio;
        }

        /// <summary>
        /// Calcula o perímetro do círculo (2 * π * r)
        /// </summary>
        /// <returns>Perímetro do círculo</returns>
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }
    }
}
