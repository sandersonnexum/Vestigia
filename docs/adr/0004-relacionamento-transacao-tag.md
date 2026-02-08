# ADR 0004: Mapeamento de Relacionamento Muitos-para-Muitos entre Transação e Tag

## Status
Ativo

## Contexto
O modelo de domínio exigia que uma `Transacao` pudesse ter múltiplas `Tags` e vice-versa. Ocorreu um erro de ambiguidade pois a entidade `Tag` possuía uma propriedade de navegação singular e uma coleção simultaneamente.

## Decisão
1. **Refatoração:** Removemos a propriedade `Transacao` (singular) da entidade `Tag`, mantendo apenas `ICollection<Transacao>`.
2. **Configuração Fluente:** Utilizamos a Fluent API para mapear a tabela de junção `TransacaoTag` explicitamente, definindo as chaves estrangeiras `IdTransacao` e `IdTag` conforme o modelo lógico do projeto.

## Consequências
* **Positivas:** Resolução do erro de criação do `DbContext` e alinhamento com a estrutura de banco de dados normalizada.
* **Negativas:** Exige o uso de `.Include(t => t.Tags)` em consultas para carregar as etiquetas associadas.