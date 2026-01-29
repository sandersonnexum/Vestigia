namespace Vestigia.Domain.Enums
{
    public enum StatusTransacao
    {
        /// A transação já foi efetivada e o dinheiro saiu/entrou na conta.
        Concluida = 1,

        /// Lançamento futuro ou agendado (essencial para o fluxo de caixa previsto).
        Pendente = 2,

        /// Transação que foi estornada ou cancelada pelo usuário.
        Cancelada = 3,

        /// Identificada pela IA como uma recorrência provável, mas ainda não confirmada pelo usuário.
        SugeridaPelaIA = 4
    }
}