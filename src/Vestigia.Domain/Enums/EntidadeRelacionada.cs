namespace Vestigia.Domain.Enums
{
    public enum EntidadeRelacionada
    {
        /// O insight é sobre o usuário ou sua saúde financeira geral.
        /// (IdEntidadeRelacionada = IdUsuario)
        Usuario = 1,

        /// O insight é específico sobre uma transação.
        /// Ex: Uma transação duplicada ou mal categorizada.
        Transacao = 2,

        /// O insight é sobre uma conta específica.
        /// Ex: Conta com saldo muito baixo ou parada sem rendimento.
        Conta = 3,

        /// O insight refere-se a uma meta financeira.
        /// Ex: Ritmo de economia insuficiente para atingir a meta.
        MetaFinanceira = 4,

        /// O insight refere-se a uma recorrência/assinatura detectada.
        Recorrencia = 5
    }
}