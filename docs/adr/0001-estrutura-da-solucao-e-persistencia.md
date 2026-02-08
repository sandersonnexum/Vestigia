# ADR 0001: Estrutura da Solução e Camada de Persistência

## Status
Ativo

## Contexto
O projeto **Vestigia** precisa de uma base robusta para suportar automação por IA e garantir um SLA de resposta inferior a 1 segundo. É necessário definir o padrão arquitetural e a tecnologia de banco de dados.

## Decisão
1. **Arquitetura:** Adotaremos **Clean Architecture** para garantir a separação de preocupações e testabilidade.
2. **Persistência:** Utilizaremos **SQL Server** com **Entity Framework Core**.
3. **Logs de Performance:** Implementaremos tabelas de `LogSaldo` e `RelatorioIA` separadas para otimizar a performance analítica sem onerar as tabelas transacionais.

## Consequências
* **Positivas:** Facilidade na evolução para serviços em nuvem (Azure) e manutenção modular.
* **Negativas:** Maior complexidade inicial na configuração de mapeamentos do EF Core entre as camadas de `Domain` e `Infrastructure`.