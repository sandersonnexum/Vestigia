namespace Vestigia.Domain.Enums
{
    public enum TipoTransacao
    {
        /// Entrada de recursos (ex: Salário, Rendimentos, Vendas).
        /// Categorias com esse tipo: "Salário", "Dividendos", "Cashback".
        Receita = 1,

        /// Saída de recursos (ex: Compras, Contas, Investimentos).
        /// Categorias com esse tipo: "Alimentação", "Transporte", "Investimentos".
        Despesa = 2,

        /// Transferência entre contas do usuário (ex: Transferência entre contas bancárias).
        Transferencia = 3
    }
}