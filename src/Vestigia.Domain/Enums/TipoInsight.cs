namespace Vestigia.Domain.Enums
{
    public enum TipoInsight
    {
        /// A IA sugere uma categoria para uma transação que estava "Sem Categoria".
        /// Ex: "Identificamos que 'Netflix' costuma ser 'Lazer'".
        ClassificacaoAutomatica = 1,

        /// Previsão de fluxo de caixa futuro.
        /// Ex: "Com base no histórico, seu saldo ficará negativo dia 15".
        PrevisaoSaldo = 2,

        /// Detecção de valor fora do padrão (Outlier).
        /// Ex: "Você gastou 300% a mais em alimentação este mês".
        AnomaliaDeGasto = 3,

        /// Sugestão para poupar dinheiro.
        /// Ex: "Você tem duas assinaturas de streaming parecidas".
        OportunidadeEconomia = 4,

        /// Análise de comportamento do usuário.
        /// Ex: "Você costuma gastar mais aos finais de semana".
        AnaliseComportamental = 5
    }
}