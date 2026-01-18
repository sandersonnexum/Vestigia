 namespace Vestigia.Domain.Entities
{
    public class Usuario
    {
        private Guid Id {get; set;}
        private string Nome {get; set;}
        private string Email {get; set;}
        private string SenhaHash {get; set;}
        private bool Ativo {get; set;}
        private DateTime DataCriacao {get;set;}

        public Usuario(string nomeConta, string email, string senha, DateTime data)
        {
            Id = Guid.NewGuid();
            Nome = nomeConta;
            Email = email;
            SenhaHash = senha;
            Ativo = true;
            DataCriacao = data;
        }
        public ICollection<Conta> Contas { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }
        public ICollection<Alerta> Alertas { get; set; }
        public ICollection<InsightIA> InsightsIA { get; set; }
        public ICollection<Relatorio> Relatorios { get; set; }

        private Usuario() {}
    }
}