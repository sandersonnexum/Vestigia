namespace Vestigia.Domain.Enums
{
    public enum TipoAlerta
    {
        /// Avisos gerais do sistema (ex: boas-vindas, manutenção programada).
        Sistema = 1,

        /// Alertas de segurança (ex: login em novo dispositivo, alteração de senha).
        Segurança = 2,

        /// Lembretes de contas a pagar ou datas de vencimento próximas.
        Vencimento = 3,

        /// Avisos sobre metas (ex: Meta atingida ou risco de não atingir o prazo).
        Metas = 4,

        /// Recomendações geradas pela IA (ex: "Você gastou 20% a mais em Lazer este mês").
        InsightsIA = 5,

        /// Notificação de erro em alguma integração ou processamento.
        Erro = 6
    }
}