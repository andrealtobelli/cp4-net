# Testes de Formas Geométricas

Link para testes: http://localhost:8080/swagger-ui


## 🟢 Teste 1 - Área
```json
{
  "tipoForma": "circulo",
  "parametros": {
    "raio": 5.0
  }
}
```
## 🟢 Teste 2 - Perímetro
```json
{
  "tipoForma": "retangulo",
  "parametros": {
    "largura": 10.0,
    "altura": 8.0
  }
}
```
## 🟢 Teste 3 - Volume
```json
{
  "tipoForma": "esfera",
  "parametros": {
    "raio": 3.0
  }
}
```

## 🟢 Teste 4 - Área Superficial
```json
{
  "tipoForma": "esfera",
  "parametros": {
    "raio": 4.0
  }
}

```
## 🟢 Teste 5 - Verificação de Contenção
```json
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

## 👥 Desenvolvedores

- Leticia Cristina Dos Santos Passos RM: 555241
- André Rogério Vieira Pavanela Altobelli Antunes RM: 554764
- Enrico Figueiredo Del Guerra RM: 558604
