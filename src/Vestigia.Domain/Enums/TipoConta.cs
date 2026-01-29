namespace Vestigia.Domain.Enums
{
    public enum TipoConta
    {
        /// Movimentação diária, saldo disponível imediato.
        ContaCorrente = 1,

        /// Reserva de valor com baixo risco.
        ContaPoupanca = 2,

        /// Gera fatura e não afeta o saldo imediato (passivo).
        CartaoCredito = 3,

        /// Renda Fixa, Ações, Tesouro (foco em valorização).
        Investimento = 4,

        /// Controle manual de dinheiro físico.
        Dineheiro = 5,

        /// PayPal, PicPay, etc.
        CarteiraDigital = 6,

        /// Outros tipos não categorizados.
        Outros = 7
    }
}