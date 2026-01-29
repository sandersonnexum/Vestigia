namespace Vestigia.Domain.Enums
{
    public enum NivelPrioridade
    {
        /// Informativo. Não requer ação imediata.
        /// Ex: "Dica de economia", "Resumo semanal disponível".
        Baixa = 1,

        /// Importante, mas pode aguardar.
        /// Ex: "Aviso de vencimento em 5 dias", "Meta atingiu 50%".
        Media = 2,

        /// Requer atenção no curto prazo.
        /// Ex: "Conta vence hoje", "Gasto muito acima da média detectado".
        Alta = 3,

        /// Urgente. Risco imediato ou ação crítica necessária.
        /// Ex: "Transação suspeita", "Saldo negativo".
        Critico = 4
    }
}