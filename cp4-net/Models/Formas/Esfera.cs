using cp4_net.Interfaces;

namespace cp4_net.Models.Formas
{
    /// <summary>
    /// Representa uma esfera com cálculos de volume e área superficial
    /// </summary>
    public class Esfera : ICalculos3D
    {
        /// <summary>
        /// Raio da esfera
        /// </summary>
        public double Raio { get; set; }

        /// <summary>
        /// Construtor da esfera
        /// </summary>
        /// <param name="raio">Raio da esfera</param>
        public Esfera(double raio)
        {
            Raio = raio;
        }

        /// <summary>
        /// Calcula o volume da esfera (4/3 * π * r³)
        /// </summary>
        /// <returns>Volume da esfera</returns>
        public double CalcularVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Raio, 3);
        }

        /// <summary>
        /// Calcula a área superficial da esfera (4 * π * r²)
        /// </summary>
        /// <returns>Área superficial da esfera</returns>
        public double CalcularAreaSuperficial()
        {
            return 4 * Math.PI * Raio * Raio;
        }
    }
}
