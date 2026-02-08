using Vestigia.Domain.ValueObjects;

namespace Vestigia.Domain.Entities
{
    public class Usuario
    {
        public Guid Id {get; private set;}
        public Nome Nome {get; private set;}
        public Email Email {get; private set;}
        public string SenhaHash {get; private set;}
        public string Username {get; private set;}  
        public bool Ativo {get; private set;}
        public DateTime DataCriacao {get; private set;}

        public Usuario(Nome nomeConta, Email email, string senha, string user, DateTime data)
        {
            Id = Guid.NewGuid();
            Nome = nomeConta;
            Email = email;
            SenhaHash = senha;
            Username = user;
            Ativo = true;
            DataCriacao = data;
        }
        public ICollection<Conta> Contas { get; set; }
        public ICollection<RelatorioIA> Relatorios { get; set; }
        public ICollection<Alerta> Alertas { get; set; }
        public ICollection<Lembrete> Lembretes { get; set; }
        public ICollection<Meta> Metas { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    
        private Usuario() {}
    }
}