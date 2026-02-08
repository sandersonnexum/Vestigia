# ADR 0002: Encapsulamento de Entidades e Mapeamento de Propriedades

## Status
Ativo

## Contexto
Para evitar estados inválidos nas entidades de domínio (ex: uma transação com valor negativo sem passar por validação), as classes foram refatoradas. Anteriormente, utilizava-se atributos privados, o que dificultava o mapeamento padrão do EF Core.

## Decisão
1. **Propriedades:** Utilizaremos propriedades públicas com `set` privado (`public T Propriedade { get; private set; }`).
2. **Value Objects:** Essa estrutura permite que o EF Core mapeie os campos corretamente enquanto o domínio protege a lógica de negócio.
3. **Mapeamento:** O `VestigiaContext` utiliza a API Fluente para configurar precisão decimal (18,2) globalmente e definir chaves primárias e estrangeiras explicitamente.

## Consequências
* **Positivas:** Maior segurança no domínio. O banco de dados reflete fielmente o modelo de classes.
* **Negativas:** Exige maior esforço na escrita das migrações e configuração do `OnModelCreating`, pois o EF precisa "entender" como acessar os setters privados.