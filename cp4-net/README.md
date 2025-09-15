# GeoMaster API - API de Cálculos Geométricos

## Visão Geral

A GeoMaster API é uma API RESTful desenvolvida em .NET 9 para realizar cálculos geométricos complexos. Esta API foi projetada seguindo os princípios SOLID e as melhores práticas de Clean Code, focando em uma arquitetura limpa, extensível e bem documentada.

## Arquitetura e Princípios SOLID

### 1. Single Responsibility Principle (SRP)
- **ICalculos2D**: Responsável apenas por cálculos de formas 2D (área e perímetro)
- **ICalculos3D**: Responsável apenas por cálculos de formas 3D (volume e área superficial)
- **CalculadoraService**: Responsável apenas por orquestrar os cálculos
- **FormaFactory**: Responsável apenas por criar instâncias de formas

### 2. Interface Segregation Principle (ISP)
- Interfaces segregadas por dimensionalidade (2D vs 3D)
- Cada interface contém apenas os métodos necessários para seu domínio

### 3. Dependency Inversion Principle (DIP)
- Controllers dependem de abstrações (ICalculadoraService)
- Injeção de dependência configurada no Program.cs

### 4. Open/Closed Principle (OCP)
- Sistema extensível para novas formas sem modificar código existente
- Uso de pattern matching para descoberta dinâmica de tipos
- Factory pattern para criação de formas

## Estrutura do Projeto

```
cp4-net/
├── Controllers/
│   ├── CalculosController.cs      # Endpoints de cálculos
│   └── ValidacoesController.cs    # Endpoints de validação
├── Interfaces/
│   ├── ICalculos2D.cs            # Interface para formas 2D
│   ├── ICalculos3D.cs            # Interface para formas 3D
│   └── ICalculadoraService.cs    # Interface do serviço principal
├── Models/
│   ├── DTOs/                      # Data Transfer Objects
│   │   ├── CalculoRequest.cs
│   │   ├── CalculoResponse.cs
│   │   └── ContencaoRequest.cs
│   └── Formas/                    # Modelos de formas geométricas
│       ├── Circulo.cs
│       ├── Retangulo.cs
│       └── Esfera.cs
├── Services/
│   ├── CalculadoraService.cs      # Serviço principal
│   └── FormaFactory.cs            # Factory para criação de formas
└── Program.cs                     # Configuração da aplicação
```

## Formas Geométricas Suportadas

### Formas 2D
- **Círculo**: Cálculo de área (π × r²) e perímetro (2 × π × r)
- **Retângulo**: Cálculo de área (largura × altura) e perímetro (2 × (largura + altura))

### Formas 3D
- **Esfera**: Cálculo de volume (4/3 × π × r³) e área superficial (4 × π × r²)

## Endpoints da API

### Cálculos Básicos
- `POST /api/v1/calculos/area` - Calcula área de formas 2D
- `POST /api/v1/calculos/perimetro` - Calcula perímetro de formas 2D
- `POST /api/v1/calculos/volume` - Calcula volume de formas 3D
- `POST /api/v1/calculos/area-superficial` - Calcula área superficial de formas 3D

### Validações
- `POST /api/v1/validacoes/forma-contida` - Verifica se uma forma está contida em outra

## Exemplos de Uso

### Calcular área de um círculo
```json
POST /api/v1/calculos/area
{
  "tipoForma": "circulo",
  "parametros": {
    "raio": 5.0
  }
}
```

### Verificar contenção
```json
POST /api/v1/validacoes/forma-contida
{
  "formaExterna": {
    "tipoForma": "retangulo",
    "parametros": {
      "largura": 10.0,
      "altura": 10.0
    }
  },
  "formaInterna": {
    "tipoForma": "circulo",
    "parametros": {
      "raio": 5.0
    }
  }
}
```

## Algoritmos de Contenção

A API implementa algoritmos matemáticos precisos para verificação de contenção:

1. **Círculo em Retângulo**: Verifica se o diâmetro (2 × raio) cabe nas dimensões do retângulo
2. **Retângulo em Círculo**: Verifica se a diagonal do retângulo cabe no diâmetro do círculo
3. **Retângulo em Retângulo**: Comparação direta das dimensões
4. **Círculo em Círculo**: Comparação dos raios

## Validações

- Parâmetros devem ser positivos (> 0)
- Tipos de forma devem ser suportados
- Validação robusta com mensagens de erro claras
- Códigos de status HTTP apropriados (400, 500)

## Documentação

- Documentação XML gerada automaticamente
- Comentários detalhados em todos os métodos públicos
- Exemplos de requisição no arquivo `GeoMaster-API-Examples.http`
- OpenAPI/Swagger integrado

## Como Executar

1. **Compilar o projeto**:
   ```bash
   dotnet build
   ```

2. **Executar a aplicação**:
   ```bash
   dotnet run
   ```

3. **Acessar a documentação**:
   - OpenAPI: `https://localhost:7041/openapi/v1.json`
   - Swagger UI: `https://localhost:7041/swagger` (se configurado)

## Extensibilidade

Para adicionar uma nova forma geométrica:

1. Implementar a interface apropriada (ICalculos2D ou ICalculos3D)
2. Adicionar o caso no FormaFactory
3. Implementar algoritmos de contenção se necessário

**Exemplo - Adicionar Triângulo**:
```csharp
public class Triangulo : ICalculos2D
{
    public double Base { get; set; }
    public double Altura { get; set; }
    
    public double CalcularArea() => (Base * Altura) / 2;
    public double CalcularPerimetro() => Base + Altura + Math.Sqrt(Base*Base + Altura*Altura);
}
```

## Tecnologias Utilizadas

- **.NET 9**: Framework principal
- **ASP.NET Core**: Web API
- **OpenAPI**: Documentação da API
- **Dependency Injection**: Inversão de controle
- **Logging**: Sistema de logs integrado

## Qualidade do Código

- **Clean Code**: Nomes descritivos, métodos curtos, responsabilidade única
- **DRY**: Eliminação de duplicação de código
- **SOLID**: Aplicação rigorosa dos princípios
- **Tratamento de Erros**: Exceções apropriadas com logging
- **Validação**: Validação robusta de entrada
