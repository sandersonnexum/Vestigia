namespace Vestigia.Domain.Enums
{
    public enum StatusMeta
    {
        /// A meta está ativa e o usuário está guardando dinheiro para ela.
        EmAndamento = 1,

        /// O valor alvo foi atingido e a meta foi concluída com sucesso.
        Atingida = 2,

        /// A meta foi temporariamente suspensa, sem contribuições novas, mas não cancelada.
        Pausada = 3,

        /// O usuário desistiu da meta e o valor pode ter sido realocado.
        Cancelada = 4
    }
}