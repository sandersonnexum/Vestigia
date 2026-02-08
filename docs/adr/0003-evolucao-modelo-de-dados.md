# ADR 0003: Evolução do Modelo de Dados para Suporte Analítico e IA

## Status
Ativo

## Contexto
Durante a evolução do projeto **Vestigia**, identificamos que o modelo inicial (v1) era puramente transacional e não oferecia dados históricos suficientes para o motor de Inteligência Artificial. Para cumprir os requisitos de "Alertas Preditivos" e "Insights de Consumo", as entidades precisavam de mais granularidade e relações explícitas com o contexto do usuário e tempo.

## Decisão
Decidimos atualizar o esquema de banco de dados e as entidades de domínio da versão 1 para a versão 2, aplicando as seguintes mudanças estruturais:

1. **Implementação do LogSaldo:** Introdução de uma entidade de série temporal vinculada ao `Usuario` e `Conta` para registrar saldos de fechamento mensais, permitindo que a IA identifique desvios de padrão.
2. **Refatoração de Metas:** A entidade `Metas` foi expandida para incluir `ValorAlcancado` e `Prazo`, permitindo o cálculo de progresso em tempo real e verificação de proximidade de prazos.
3. **Especialização de Relatórios:** O antigo `Relatorio` foi transformado em `RelatorioIA`, adicionando o campo `EntidadeRelacionada`. Isso permite que um insight seja vinculado especificamente a uma Conta, Meta ou Categoria.
4. **Desacoplamento de Categoria e Tag:** Ajuste no relacionamento para permitir que as `Tags` sejam transversais e as `Categorias` sejam o eixo principal de classificação para o motor de IA.
5. **Tipagem Forte com Enums:** Substituição de tipos primitivos por Enums específicos (`StatusMeta`, `TipoRelatorio`, `TipoAlerta`) para garantir que a lógica de estado seja consistente entre o banco e a aplicação.

## Consequências
* **Positivas:** * O sistema agora possui um histórico rico (LogSaldo) para alimentar modelos de regressão ou análise de tendência.
    * Melhor separação de responsabilidades entre o que é um registro financeiro (Transação) e o que é um insight gerado (RelatorioIA).
    * Maior precisão no acompanhamento de objetivos financeiros.
* **Negativas:** * Maior complexidade nas consultas de persistência (Infrastructure), exigindo mapeamentos mais detalhados no `VestigiaContext`.
    * Necessidade de migrações de dados caso existam registros na versão anterior.