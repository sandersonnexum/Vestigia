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

        public Usuario(Guid id, Nome nome, Email email, string senha, string username, bool ativo, DateTime data)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SenhaHash = senha;
            Username = username;
            Ativo = ativo;
            DataCriacao = data;
        }

        public void AtualizarUsuario(Nome nome, Email email, string senha, string username, bool ativo)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senha;
            Username = username;
            Ativo = ativo;
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