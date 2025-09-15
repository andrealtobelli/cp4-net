using cp4_net.Models.Formas;

namespace cp4_net.Interfaces
{
    /// <summary>
    /// Interface para o serviço de cálculos geométricos
    /// </summary>
    public interface ICalculadoraService
    {
        /// <summary>
        /// Calcula a área de uma forma 2D
        /// </summary>
        /// <param name="forma">Forma geométrica 2D</param>
        /// <returns>Área da forma</returns>
        double CalcularArea(object forma);

        /// <summary>
        /// Calcula o perímetro de uma forma 2D
        /// </summary>
        /// <param name="forma">Forma geométrica 2D</param>
        /// <returns>Perímetro da forma</returns>
        double CalcularPerimetro(object forma);

        /// <summary>
        /// Calcula o volume de uma forma 3D
        /// </summary>
        /// <param name="forma">Forma geométrica 3D</param>
        /// <returns>Volume da forma</returns>
        double CalcularVolume(object forma);

        /// <summary>
        /// Calcula a área superficial de uma forma 3D
        /// </summary>
        /// <param name="forma">Forma geométrica 3D</param>
        /// <returns>Área superficial da forma</returns>
        double CalcularAreaSuperficial(object forma);

        /// <summary>
        /// Verifica se uma forma interna está contida em uma forma externa
        /// </summary>
        /// <param name="formaExterna">Forma que deve conter a outra</param>
        /// <param name="formaInterna">Forma que deve estar contida</param>
        /// <returns>True se a forma interna está contida na externa</returns>
        bool VerificarContencao(object formaExterna, object formaInterna);
    }
}
