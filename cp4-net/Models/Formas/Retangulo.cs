using cp4_net.Interfaces;

namespace cp4_net.Models.Formas
{
    /// <summary>
    /// Representa um retângulo com cálculos de área e perímetro
    /// </summary>
    public class Retangulo : ICalculos2D
    {
        /// <summary>
        /// Largura do retângulo
        /// </summary>
        public double Largura { get; set; }

        /// <summary>
        /// Altura do retângulo
        /// </summary>
        public double Altura { get; set; }

        /// <summary>
        /// Construtor do retângulo
        /// </summary>
        /// <param name="largura">Largura do retângulo</param>
        /// <param name="altura">Altura do retângulo</param>
        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }

        /// <summary>
        /// Calcula a área do retângulo (largura * altura)
        /// </summary>
        /// <returns>Área do retângulo</returns>
        public double CalcularArea()
        {
            return Largura * Altura;
        }

        /// <summary>
        /// Calcula o perímetro do retângulo (2 * (largura + altura))
        /// </summary>
        /// <returns>Perímetro do retângulo</returns>
        public double CalcularPerimetro()
        {
            return 2 * (Largura + Altura);
        }
    }
}
