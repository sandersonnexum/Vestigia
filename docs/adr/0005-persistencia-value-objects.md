# ADR 0005: Persistência de Value Objects via Owned Entity Types

## Status
Ativo

## Contexto
O projeto **Vestigia** adota o padrão de Domain-Driven Design (DDD), utilizando Value Objects (OVs) como `Email`, `Nome` e `Monetario` para encapsular lógicas de validação e garantir a integridade dos dados. 

Ao mapear essas classes para o banco de dados SQL Server via Entity Framework Core, o ORM, por convenção, tenta tratá-las como entidades independentes, exigindo chaves primárias (PKs) que os OVs não possuem.

## Decisão
Decidimos utilizar o mapeamento de **Owned Entity Types** (Tipos Dependentes) através do método `OwnsOne` na Fluent API do `VestigiaContext`. 

Esta abordagem garante que:
1. **Identidade:** Os Value Objects não possuam chaves primárias próprias, sendo identificados pela entidade proprietária (ex: `Usuario` ou `Conta`).
2. **Esquema de Banco:** As propriedades internas dos OVs (como `Texto`, `Endereco` ou `Valor`) sejam persistidas como colunas diretamente na tabela da entidade pai, evitando JOINS desnecessários e mantendo o SLA de performance inferior a 1 segundo.
3. **Encapsulamento:** O domínio continue utilizando objetos ricos, enquanto a camada de infraestrutura resolve a tradução para tipos primitivos do SQL Server.

## Consequências
* **Positivas:** * Garantia de que nenhum dado financeiro ou de usuário entre no banco sem passar pelas validações de domínio.
    * Esquema de banco de dados limpo e alinhado com o Modelo Lógico.
* **Negativas:** * Aumento da verbosidade no `OnModelCreating`, exigindo mapeamento explícito para cada propriedade que utilize OVs.