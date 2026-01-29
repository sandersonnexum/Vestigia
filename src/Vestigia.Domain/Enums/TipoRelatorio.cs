namespace Vestigia.Domain.Enums
{
    public enum TipoRelatorio
    {
        /// Relatório padrão de entradas e saídas no período (Extrato consolidado).
        FluxoCaixa = 1,

        /// Agrupa os gastos por tipo (Alimentação, Transporte, etc.).
        /// Essencial para entender para onde o dinheiro está indo.
        DepesasPorCategoria = 2,

        /// Compara o período atual com o anterior (ex: Este mês vs Mês passado).
        ComparativoPeriodos = 3,

        /// Relatório focado no progresso das metas financeiras definidas.
        AcompanhamentoMetas = 4,

        /// Relatório gerado pela IA com projeções futuras baseadas no histórico.
        PrevisaoInteligente = 5,

        /// Relatório fiscal ou para imposto de renda (Renda anual).
        InformeRendimentos = 6
    }
}