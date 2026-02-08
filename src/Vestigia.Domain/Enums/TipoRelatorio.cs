namespace Vestigia.Domain.Enums
{
    public enum TipoRelatorio
    {
        /// Relatório padrão de entradas e saídas no período (Extrato consolidado).
        FluxoCaixa = 1,

        /// Previsão de fluxo de caixa futuro.
        /// Ex: "Com base no histórico, seu saldo ficará negativo dia 15".
        PrevisaoSaldo = 2,

        /// Detecção de valor fora do padrão (Outlier).
        /// Ex: "Você gastou 300% a mais em alimentação este mês".
        AnomaliaDeGasto = 3,

        /// Agrupa os gastos por tipo (Alimentação, Transporte, etc.).
        /// Essencial para entender para onde o dinheiro está indo.
        DepesasPorCategoria = 4,

        /// Compara o período atual com o anterior (ex: Este mês vs Mês passado).
        ComparativoPeriodos = 5,

        /// Sugestão para poupar dinheiro.
        /// Ex: "Você tem duas assinaturas de streaming parecidas".
        OportunidadeEconomia = 6,

        /// Relatório focado no progresso das metas financeiras definidas.
        AcompanhamentoMetas = 7,

        /// Relatório gerado pela IA com projeções futuras baseadas no histórico.
        PrevisaoInteligente = 8,

        /// Relatório fiscal ou para imposto de renda (Renda anual).
        InformeRendimentos = 9
    }
}