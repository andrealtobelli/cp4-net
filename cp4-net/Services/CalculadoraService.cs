using cp4_net.Interfaces;
using cp4_net.Models.Formas;

namespace cp4_net.Services
{
    /// <summary>
    /// Serviço responsável por executar cálculos geométricos
    /// </summary>
    public class CalculadoraService : ICalculadoraService
    {
        /// <summary>
        /// Calcula a área de uma forma 2D
        /// </summary>
        /// <param name="forma">Forma geométrica 2D</param>
        /// <returns>Área da forma</returns>
        /// <exception cref="ArgumentException">Quando a forma não implementa ICalculos2D</exception>
        public double CalcularArea(object forma)
        {
            if (forma is ICalculos2D forma2D)
            {
                return forma2D.CalcularArea();
            }
            
            throw new ArgumentException("A forma fornecida não suporta cálculos 2D", nameof(forma));
        }

        /// <summary>
        /// Calcula o perímetro de uma forma 2D
        /// </summary>
        /// <param name="forma">Forma geométrica 2D</param>
        /// <returns>Perímetro da forma</returns>
        /// <exception cref="ArgumentException">Quando a forma não implementa ICalculos2D</exception>
        public double CalcularPerimetro(object forma)
        {
            if (forma is ICalculos2D forma2D)
            {
                return forma2D.CalcularPerimetro();
            }
            
            throw new ArgumentException("A forma fornecida não suporta cálculos 2D", nameof(forma));
        }

        /// <summary>
        /// Calcula o volume de uma forma 3D
        /// </summary>
        /// <param name="forma">Forma geométrica 3D</param>
        /// <returns>Volume da forma</returns>
        /// <exception cref="ArgumentException">Quando a forma não implementa ICalculos3D</exception>
        public double CalcularVolume(object forma)
        {
            if (forma is ICalculos3D forma3D)
            {
                return forma3D.CalcularVolume();
            }
            
            throw new ArgumentException("A forma fornecida não suporta cálculos 3D", nameof(forma));
        }

        /// <summary>
        /// Calcula a área superficial de uma forma 3D
        /// </summary>
        /// <param name="forma">Forma geométrica 3D</param>
        /// <returns>Área superficial da forma</returns>
        /// <exception cref="ArgumentException">Quando a forma não implementa ICalculos3D</exception>
        public double CalcularAreaSuperficial(object forma)
        {
            if (forma is ICalculos3D forma3D)
            {
                return forma3D.CalcularAreaSuperficial();
            }
            
            throw new ArgumentException("A forma fornecida não suporta cálculos 3D", nameof(forma));
        }

        /// <summary>
        /// Verifica se uma forma interna está contida em uma forma externa
        /// </summary>
        /// <param name="formaExterna">Forma que deve conter a outra</param>
        /// <param name="formaInterna">Forma que deve estar contida</param>
        /// <returns>True se a forma interna está contida na externa</returns>
        public bool VerificarContencao(object formaExterna, object formaInterna)
        {
            return (formaExterna, formaInterna) switch
            {
                (Retangulo ret, Circulo circ) => VerificarCirculoEmRetangulo(ret, circ),
                (Circulo circ, Retangulo ret) => VerificarRetanguloEmCirculo(circ, ret),
                (Retangulo ret1, Retangulo ret2) => VerificarRetanguloEmRetangulo(ret1, ret2),
                (Circulo circ1, Circulo circ2) => VerificarCirculoEmCirculo(circ1, circ2),
                _ => throw new ArgumentException("Combinação de formas não suportada para verificação de contenção")
            };
        }

        /// <summary>
        /// Verifica se um círculo está contido em um retângulo
        /// </summary>
        private static bool VerificarCirculoEmRetangulo(Retangulo retangulo, Circulo circulo)
        {
            // O círculo está contido se o diâmetro (2 * raio) cabe tanto na largura quanto na altura
            return 2 * circulo.Raio <= retangulo.Largura && 2 * circulo.Raio <= retangulo.Altura;
        }

        /// <summary>
        /// Verifica se um retângulo está contido em um círculo
        /// </summary>
        private static bool VerificarRetanguloEmCirculo(Circulo circulo, Retangulo retangulo)
        {
            // O retângulo está contido se a diagonal cabe no diâmetro do círculo
            // Diagonal = sqrt(largura² + altura²)
            double diagonal = Math.Sqrt(retangulo.Largura * retangulo.Largura + retangulo.Altura * retangulo.Altura);
            return diagonal <= 2 * circulo.Raio;
        }

        /// <summary>
        /// Verifica se um retângulo está contido em outro retângulo
        /// </summary>
        private static bool VerificarRetanguloEmRetangulo(Retangulo retanguloExterno, Retangulo retanguloInterno)
        {
            return retanguloInterno.Largura <= retanguloExterno.Largura && 
                   retanguloInterno.Altura <= retanguloExterno.Altura;
        }

        /// <summary>
        /// Verifica se um círculo está contido em outro círculo
        /// </summary>
        private static bool VerificarCirculoEmCirculo(Circulo circuloExterno, Circulo circuloInterno)
        {
            return circuloInterno.Raio <= circuloExterno.Raio;
        }
    }
}
