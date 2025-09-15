using cp4_net.Models.Formas;

namespace cp4_net.Services
{
    /// <summary>
    /// Factory para criar formas geométricas a partir de parâmetros
    /// </summary>
    public static class FormaFactory
    {
        /// <summary>
        /// Cria uma forma geométrica baseada no tipo e parâmetros fornecidos
        /// </summary>
        /// <param name="tipoForma">Tipo da forma (circulo, retangulo, esfera)</param>
        /// <param name="parametros">Parâmetros da forma</param>
        /// <returns>Instância da forma criada</returns>
        /// <exception cref="ArgumentException">Quando o tipo de forma não é suportado</exception>
        public static object CriarForma(string tipoForma, Dictionary<string, double> parametros)
        {
            return tipoForma.ToLower() switch
            {
                "circulo" => CriarCirculo(parametros),
                "retangulo" => CriarRetangulo(parametros),
                "esfera" => CriarEsfera(parametros),
                _ => throw new ArgumentException($"Tipo de forma '{tipoForma}' não é suportado")
            };
        }

        /// <summary>
        /// Cria um círculo a partir dos parâmetros
        /// </summary>
        private static Circulo CriarCirculo(Dictionary<string, double> parametros)
        {
            if (!parametros.TryGetValue("raio", out double raio))
                throw new ArgumentException("Parâmetro 'raio' é obrigatório para círculo");

            if (raio <= 0)
                throw new ArgumentException("O raio deve ser maior que zero");

            return new Circulo(raio);
        }

        /// <summary>
        /// Cria um retângulo a partir dos parâmetros
        /// </summary>
        private static Retangulo CriarRetangulo(Dictionary<string, double> parametros)
        {
            if (!parametros.TryGetValue("largura", out double largura))
                throw new ArgumentException("Parâmetro 'largura' é obrigatório para retângulo");

            if (!parametros.TryGetValue("altura", out double altura))
                throw new ArgumentException("Parâmetro 'altura' é obrigatório para retângulo");

            if (largura <= 0)
                throw new ArgumentException("A largura deve ser maior que zero");

            if (altura <= 0)
                throw new ArgumentException("A altura deve ser maior que zero");

            return new Retangulo(largura, altura);
        }

        /// <summary>
        /// Cria uma esfera a partir dos parâmetros
        /// </summary>
        private static Esfera CriarEsfera(Dictionary<string, double> parametros)
        {
            if (!parametros.TryGetValue("raio", out double raio))
                throw new ArgumentException("Parâmetro 'raio' é obrigatório para esfera");

            if (raio <= 0)
                throw new ArgumentException("O raio deve ser maior que zero");

            return new Esfera(raio);
        }
    }
}
