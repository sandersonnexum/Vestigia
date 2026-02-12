# ADR 0006: Criação de Value Objects via Factory Method

## Status

Ativo

## Contexto

O projeto **Vestigia** adota Domain-Driven Design (DDD), utilizando
Value Objects como `Nome`, `Email` e `Monetario` para garantir
validação, imutabilidade e integridade do domínio.

Durante a implementação dos Use Cases na camada **Application**, foi
identificado que os construtores dos Value Objects estavam com nível de
proteção restrito (`private`), impedindo sua instanciação direta fora do
domínio e gerando o erro:

is inaccessible due to its protection level

Alterar o construtor para `public` resolveria o problema técnico, porém
enfraqueceria o encapsulamento e permitiria a criação de objetos
potencialmente inválidos fora das regras de negócio.

Era necessário manter:

-   Proteção das invariantes de domínio\
-   Centralização das validações\
-   Imutabilidade do Value Object\
-   Independência da camada Application em relação às regras internas

## Decisão

Foi adotado o padrão **Factory Method estático (`Criar`)** para a
construção de Value Objects.

Estrutura definida:

``` csharp
public class Nome
{
    public string Valor { get; }

    private Nome(string valor)
    {
        Valor = valor;
    }

    public static Nome Criar(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("Nome inválido");

        return new Nome(valor);
    }
}
```

Com essa abordagem:

1.  O construtor permanece `private`, impedindo criação indevida.
2.  A validação fica centralizada no próprio Value Object.
3.  A camada Application apenas solicita a criação via método explícito.
4.  Mantém-se a integridade do modelo rico de domínio.

## Consequências

### Positivas

-   Garantia de que todo Value Object criado passou pelas validações de
    domínio.
-   Preservação da imutabilidade.
-   Manutenção do encapsulamento e da coerência com DDD.
-   Eliminação de erros de proteção de acesso entre camadas.
-   Código mais explícito quanto à intenção de criação de objetos
    válidos.

### Negativas

-   Leve aumento de verbosidade na camada Application.
-   Necessidade de padronização para todos os Value Objects.
-   Possível duplicação de métodos `Criar` caso não exista uma abstração
    base.

## Impacto Arquitetural

A decisão reforça a separação clara entre:

-   **Application:** orquestra o fluxo de execução\
-   **Domain:** protege regras e invariantes\
-   **Infrastructure:** resolve persistência (via Owned Entity Types --
    ADR 0005)

Essa decisão consolida o Vestigia como um domínio rico, evitando
anemização do modelo.
